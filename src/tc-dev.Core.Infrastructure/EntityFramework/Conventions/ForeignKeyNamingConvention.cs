using System.Collections.Generic;
using System.Data.Entity.Core.Metadata.Edm;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using tc_dev.Core.Common.Utilities;

namespace tc_dev.Core.Infrastructure.EntityFramework.Conventions
{
    public class ForeignKeyNamingConvention : IStoreModelConvention<AssociationType>
    {
        public void Apply(AssociationType association, DbModel model) {
            if (!association.IsForeignKey) return;

            var constraint = association.Constraint;

            if (DoPropertiesHaveDefaultNames(constraint.FromProperties, constraint.ToProperties)) {
                NormalizeForeignKeyProperties(constraint.FromProperties);
            }
            if (DoPropertiesHaveDefaultNames(constraint.ToProperties, constraint.FromProperties)) {
                NormalizeForeignKeyProperties(constraint.ToProperties);
            }
        }

        private static bool DoPropertiesHaveDefaultNames(
            IReadOnlyCollection<EdmProperty> properties, IReadOnlyList<EdmProperty> otherEndProperties) 
        {
            properties.ThrowIfNull("properties");
            otherEndProperties.ThrowIfNull("otherEndPoints");

            if (properties.Count != otherEndProperties.Count)
                return false;

            return !properties
                .Where((t, i) => !t.Name.EndsWith("_" + otherEndProperties[i].Name))
                .Any();
        }

        private static void NormalizeForeignKeyProperties(IEnumerable<EdmProperty> properties) {
            foreach (var t in properties) {
                var defaultPropertyName = t.Name;
                var ichUnderscore = defaultPropertyName.IndexOf('_');

                if (ichUnderscore <= 0)
                    continue;

                var navigationPropertyName = defaultPropertyName.Substring(0, ichUnderscore);
                var targetKey = defaultPropertyName.Substring(ichUnderscore + 1);

                string newPropertyName;

                if (targetKey.StartsWith(navigationPropertyName))
                    newPropertyName = targetKey;
                else
                    newPropertyName = navigationPropertyName + targetKey;

                t.Name = newPropertyName;
            }
        }
    }
}

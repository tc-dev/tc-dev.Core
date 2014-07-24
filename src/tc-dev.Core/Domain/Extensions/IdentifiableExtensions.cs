using tc_dev.Core.Common.Utilities;

namespace tc_dev.Core.Domain.Extensions
{
    public static class IdentifiableExtensions
    {
        public static bool IsNew(this IIdentifiable source) {
            source.ThrowIfNull("source");

            return source.Id == 0;
        }
    }
}

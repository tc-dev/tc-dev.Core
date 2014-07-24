using System;

namespace tc_dev.Core.Domain
{
    public abstract class BaseEntity : IIdentifiable
    {
        public int Id { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime? DateLastModified { get; set; }
    }
}

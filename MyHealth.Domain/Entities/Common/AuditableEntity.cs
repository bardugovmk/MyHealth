using System;
using System.Collections.Generic;
using System.Text;

namespace MyHealth.Domain.Entities.Common
{
    public abstract class AuditableEntity : BaseEntity
    {
        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public bool IsDeleted { get; set; }
    }
}

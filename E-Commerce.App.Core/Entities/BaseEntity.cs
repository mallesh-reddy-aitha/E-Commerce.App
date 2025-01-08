using System;
using System.Collections.Generic;
using System.Text;

namespace E_Commerce.App.Core.Entities
{
    public class BaseEntity
    {
        public long Id { get; set; }

        public Guid ModifiedBy { get; set; }

        public Guid CreatedBy { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime ModifiedOn { get; set; }

        public bool IsDefunct { get; set; }
    }
}

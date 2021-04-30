using System;
using System.Collections.Generic;

namespace RealState.Infrastructure.DataAccess
{
    public partial class Property
    {
        public Property()
        {
            PropertyImage = new HashSet<PropertyImage>();
            PropertyTrace = new HashSet<PropertyTrace>();
        }

        public int IdProperty { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public decimal Price { get; set; }
        public string CodeInternal { get; set; }
        public int? Year { get; set; }
        public int IdOwner { get; set; }

        public virtual Owner IdOwnerNavigation { get; set; }
        public virtual ICollection<PropertyImage> PropertyImage { get; set; }
        public virtual ICollection<PropertyTrace> PropertyTrace { get; set; }
    }
}

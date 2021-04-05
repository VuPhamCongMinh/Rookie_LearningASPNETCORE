using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleShop.Shared.Interfaces
{
    public interface Auditable
    {
        public DateTime createdDate { get; set; }
        public DateTime updatedDate { get; set; }
    }
}

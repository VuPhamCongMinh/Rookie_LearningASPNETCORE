using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleShop.Shared.ViewModels
{
    public class RatingResponse
    {
        public int rateValue { get; set; }
        public string comment { get; set; }
        public virtual IdentityUser User { get; set; }
        public DateTime createdDate { get; set; }
    }
}

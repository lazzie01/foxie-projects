using DataModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PremiumCalculator.Models
{
    public class MemberViewModel
    {
        public long Id { get; set; }

        public string Name { get; set; }

        [Display(Name = "Date Of Birth")]
        public string DateOfBirth { get; set; }

        [Display(Name = "Premium Payer")]
        public string PremiumPayer { get; set; }

        public long PayerId { get; set; }

        public Member ToMember()
        {
            return new Member()
            {
                Id = Id,
                Name = Name,
                DateOfBirth = DateTime.Parse(DateOfBirth),
                PayerId =PayerId>0? PayerId:(long?)null
            };
        }
    }
}
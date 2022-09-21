using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BloodDonation.Models
{
    public class BloodDonor
    {
        [Key]
        public int ID { get; set; }
        [Required(AllowEmptyStrings = true)]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public GenderList Gender { get; set; }
        public string Email { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public BloodGroupList BloodGroup { get; set; }
        public string Health { get; set; }
        public string Photo { get; set; }
    }
}

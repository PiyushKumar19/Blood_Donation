using BloodDonation.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BloodDonation.ViewModel
{
    public class DonorViewModel
    {

        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public GenderList Gender { get; set; }
        public string Email { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public BloodGroupList BloodGroup { get; set; }
        public string Health { get; set; }
        [NotMapped]
        public IFormFile Photo { get; set; }
    }
}

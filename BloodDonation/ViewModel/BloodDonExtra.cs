using BloodDonation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BloodDonation.ViewModel
{
    public class BloodDonExtra:BloodDonor
    {
        public int PatientId { get; set; }
        public string PatientName { get; set; }
        public int PatientPhoneNo { get; set; }
        public int PatientAge { get; set; }
        public ExtraGenderList PatientGender { get; set; }
    }
}

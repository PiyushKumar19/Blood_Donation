using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BloodDonation.ViewModel
{
    public class PatientRegisterViewModel:BloodDonExtra
    {
        [Display(Name="Patient Id")]
        public int Id { get; set; }
        [Display(Name="Patient Name")]
        public string Name { get; set; }
        [Display(Name="Patient Contact Number")]
        public int PatientContactNo { get; set; }
        [Display(Name="Age")]
        public int PAge { get; set; }
        [Display(Name="Enter Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Display(Name="Confirm Password")]
        [DataType(DataType.Password)]
        public string confirmpassword { get; set; }
    }
}

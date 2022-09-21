using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BloodDonation.ViewModel
{
    public class DonorEditViewModel:DonorViewModel
    {
        public int ID { get; set; }
        public string PhotoPath { get; set; }
    }
}

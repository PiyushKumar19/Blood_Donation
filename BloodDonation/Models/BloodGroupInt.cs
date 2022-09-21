using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BloodDonation.Models
{
    public interface BloodGroupInt
    {
        public BloodDonor GetID(int ID);
        IEnumerable<BloodDonor> GetData();
        BloodDonor Add(BloodDonor Bdon);
        BloodDonor Delete(int ID);
        BloodDonor Update(BloodDonor Bdonupdate);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BloodDonation.Models
{
    public class SqlBloodDonation : BloodGroupInt
    {
        private readonly DB context;
        public SqlBloodDonation(DB contextvar)          
        {
            this.context = contextvar;
        }
        public BloodDonor Add(BloodDonor Bdon)
        {
            context.BGroup.Add(Bdon);
            context.SaveChanges();
            return Bdon;
        }

        public BloodDonor Delete(int ID)
        {
            BloodDonor Bgroup = context.BGroup.Find(ID);
            if(Bgroup!=null)
            {
                context.BGroup.Remove(Bgroup);
                context.SaveChanges();
            }
            return Bgroup;
        }

        public IEnumerable<BloodDonor> GetData()
        {
            return context.BGroup;
        }

        public BloodDonor GetID(int ID)
        {
            return context.BGroup.Find(ID);
        }

        public BloodDonor Update(BloodDonor Bdonupdate)
        {
            var don = context.BGroup.Attach(Bdonupdate);
            don.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return Bdonupdate;
        }
    }
}

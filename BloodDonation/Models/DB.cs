using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BloodDonation.Models
{
    public class DB : IdentityDbContext
    {
        
        public DB( DbContextOptions options) : base(options)
        {
        }
        public DbSet<BloodDonor> BGroup { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<BloodDonor>().HasData(
                new BloodDonor
                {
                    ID=1,
                    FirstName="Piyush",
                    LastName="Kumar",
                    Age=18,
                    Gender=GenderList.Male,
                    Email="PiyushKumar@gmail.com",
                    Address="Bihari Colony",
                    BloodGroup=BloodGroupList.ABp
                },
                new BloodDonor
                {
                    ID = 2,
                    FirstName = "Harsh",
                    LastName = "Kumar",
                    Age = 18,
                    Gender = GenderList.Male,
                    Email = "HarshKumar@gmail.com",
                    Address = "Kaushambi",
                    BloodGroup = BloodGroupList.Ap
                },
                new BloodDonor
                {
                    ID = 3,
                    FirstName = "Aditya",
                    LastName = "Arora",
                    Age = 18,
                    Gender = GenderList.Male,
                    Email = "AdityaArora@gmail.com",
                    Address = "Bhola Nath Nagar",
                    BloodGroup = BloodGroupList.Bp
                },
                new BloodDonor
                {
                    ID = 4,
                    FirstName = "Himanshu",
                    LastName = "Yadav",
                    Age = 18,
                    Gender = GenderList.Male,
                    Email = "HimanshuYadav@gmail.com",
                    Address = "GokulPuri",
                    BloodGroup = BloodGroupList.Op
                }
                );
        }
       
    }
}

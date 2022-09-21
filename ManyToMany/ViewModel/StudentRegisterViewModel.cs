using ManyToMany.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ManyToMany.ViewModel
{
    public class StudentRegisterViewModel:Students
    {
        [Display(Name = "Student Id")]
        public int Id { get; set; }
        [Display(Name = "Student Name")]
        public string SName { get; set; }
        [Display(Name = "Student Father Number")]
        public string SFatherName { get; set; }
        [Display(Name = "Student Mother Number")]
        public string SMotherName { get; set; }
        [Display(Name = "Email")]
        public string SEmail { get; set; }
        [Display(Name = "Enter Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password)]
        public string confirmpassword { get; set; }
    
    }
}

using BloodDonation.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using BloodDonation.ViewModel;
using System.IO;
using CaptchaMvc;
using Microsoft.AspNetCore.Authorization;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using Newtonsoft.Json;
using BloodDonation.ServiceApi;

namespace BloodDonation.Controllers
{
    //[Authorize/*(Roles = "Guest")*/] //Commenting To Use Api
    public class HomeController : Controller
    {
        private readonly IHostingEnvironment _ihostingenvoirement;
        private BloodGroupInt donvar;
        public HomeController(BloodGroupInt donvari, IHostingEnvironment ihostingenvoirement)
        {
            this.donvar = donvari;
            this._ihostingenvoirement = ihostingenvoirement;
        }

        public async Task<Employee> PostInfoApi(Employee requestObj)
        {
            // Initialization.  
            Employee responseObj = new Employee();

            // Posting.  
            using (var client = new HttpClient())
            {
                // Setting Base address.  
                client.BaseAddress = new Uri("http://192.168.1.3:96/api/Employee");

                // Setting content type.                   
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // Initialization.  
                HttpResponseMessage response = new HttpResponseMessage();

                // HTTP POST  
                response = await client.PostAsJsonAsync("http://192.168.1.3:96/api/Employee", requestObj).ConfigureAwait(false);

                // Verification  
                if (response.IsSuccessStatusCode)
                {
                    // Reading Response.  
                    string result = response.Content.ReadAsStringAsync().Result;
                    responseObj = JsonConvert.DeserializeObject<Employee>(result);
                }
            }

            return responseObj;
        }
        public IActionResult Detail(int ID)
        {
            BloodDonor b = donvar.GetID(ID);
            return View(b);
        }
        
        public IActionResult AllDetail()
        {
            var data = donvar.GetData();
            return View(data);
        }
        public IActionResult Profile()
        {
            return View();
        }

        public IActionResult Signup()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(DonorViewModel model)
        {
            if (ModelState.IsValid)
            {
                string uniqueFileName = null;
                if (model.Photo != null)
                {
                    string uploadFolder = Path.Combine(_ihostingenvoirement.WebRootPath, "ImagesData");
                    uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Photo.FileName;
                    string filepath = Path.Combine(uploadFolder, uniqueFileName);
                    model.Photo.CopyTo(new FileStream(filepath, FileMode.Create));
                }
                BloodDonor newDonor = new BloodDonor()
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Age = model.Age,
                    Gender = model.Gender,
                    Email = model.Email,
                    City = model.City,
                    Address = model.Address,
                    BloodGroup = model.BloodGroup,
                    Health = model.Health,
                    Photo=uniqueFileName
                };
                donvar.Add(newDonor);
                return RedirectToAction("AllDetail", new { ID = newDonor.ID });
            }
            return View();
        }
        [HttpGet]
        public ViewResult Edit(int ID)
        {
            BloodDonor dono = donvar.GetID(ID);
            DonorEditViewModel donoredit = new DonorEditViewModel
            {
                ID = dono.ID,
                FirstName = dono.FirstName,
                LastName = dono.LastName,
                Age = dono.Age,
                Gender = dono.Gender,
                Email = dono.Email,
                City = dono.City,
                Address = dono.Address,
                BloodGroup = dono.BloodGroup,
                Health = dono.Health,
                PhotoPath = dono.Photo
            };
            return View(donoredit);
        }
        [HttpPost]
        public IActionResult Edit(DonorEditViewModel model)
        {
            if(ModelState.IsValid)
            {
                BloodDonor donr = donvar.GetID(model.ID);
                donr.FirstName = model.FirstName;
                donr.LastName = model.LastName;
                donr.Age = model.Age;
                donr.Gender = model.Gender;
                donr.Email = model.Email;
                donr.City = model.City;
                donr.Address = model.Address;
                donr.BloodGroup = model.BloodGroup;
                donr.Health = model.Health;
                if(model.Photo!=null)
                {
                    if(model.PhotoPath!=null)
                    {
                        string FilePath = Path.Combine(_ihostingenvoirement.WebRootPath, "ImagesData", model.PhotoPath);
                        System.IO.File.Delete(FilePath);
                    }
                    donr.Photo = ProcessUploadedFile(model);
                }
                BloodDonor Bdonupdate = donvar.Update(donr);
                return RedirectToAction("AllDetail");

            }
            return View(model);
        }
        private string ProcessUploadedFile(DonorEditViewModel model)
        {
            string uniqueFileName = null;
            if(model.Photo!=null)
            {
                string uploadFolder = Path.Combine(_ihostingenvoirement.WebRootPath, "ImagesData");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Photo.FileName;
                string FilePath = Path.Combine(uploadFolder, uniqueFileName);
                using (var file = new FileStream(FilePath, FileMode.Create)) 
                {
                    model.Photo.CopyTo(file);
                }
            }
            return uniqueFileName;
            
        }

        public IActionResult Delete(int ID)
        {
            donvar.Delete(ID);
            return RedirectToAction("AllDetail");
        }
        public IActionResult ExtraCreate()
        {
            return View();
        }
        [HttpPost]
        public IActionResult ExtraCreate(BloodDonExtra model)
        {
            if(ModelState.IsValid)
            {
                var Bdon = new BloodDonor()
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Age = model.Age,
                    Gender = model.Gender,
                    Email = model.Email,
                    City = model.City,
                    Address = model.Address,
                    BloodGroup = model.BloodGroup,
                    Health = model.Health
                };
                donvar.Add(Bdon);
                var Bdonextra = new BloodDonExtra()
                {
                    PatientId = model.PatientId,
                    PatientName = model.PatientName,
                    PatientPhoneNo = model.PatientPhoneNo,
                    PatientAge = model.PatientAge,
                    PatientGender = model.PatientGender
                };
                donvar.Add(Bdonextra);
                RedirectToAction("Home", "Index");
            }
            return View();
        }

        //private readonly ILogger<HomeController> _logger;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        
    }
}

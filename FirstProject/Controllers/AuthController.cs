using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FirstProject.Models;
using Microsoft.AspNetCore.Hosting;
using AspNetCoreHero.ToastNotification.Abstractions;
using System.IO;
using Microsoft.AspNetCore.Http;
using FirstProject.Infrastructure;

namespace FirstProject.Controllers
{
    public class AuthController : Controller
    {
        private readonly ModelContext _context;
        private readonly IWebHostEnvironment _webHostEnviroment;
        private readonly INotyfService _notyf;

        public AuthController(ModelContext context, IWebHostEnvironment webHostEnviroment, INotyfService notyf)
        {
            _context = context;
            _webHostEnviroment = webHostEnviroment;
            _notyf = notyf;
        }

        //Get
        public IActionResult Login()
        {
            //General site info
            ViewBag.siteName = _context.HeadSections.FirstOrDefault().ClinicName;
            ViewBag.siteEmail = _context.HeadSections.FirstOrDefault().ClinicEmail;
            ViewBag.siteAddress = _context.HeadSections.FirstOrDefault().ClinicAddress;
            ViewBag.siteLogo = _context.HeadSections.FirstOrDefault().ImagePath;
            ViewBag.EmaegencyCase = _context.FeaturesSections.FirstOrDefault().EmaegencyCase;

            return View();
        }
        //Post
        [HttpPost]
        public IActionResult Login(string UserName, string Password)
        {
            var Auth = _context.Users.Where(x => x.UserName == UserName && x.Password == Password).SingleOrDefault();
            if (Auth != null)
            {
                switch (Auth.RoleId)
                {
                    case 1:
                        {
                            HttpContext.Session.SetInt32("AdminId", (int)Auth.AdminId);
                            _notyf.Success("LogIn successfully", 3);
                            return RedirectToAction("Index", "AdminDashboard");
                        }
                    case 2:
                        {
                            HttpContext.Session.SetInt32("DoctorId", (int)Auth.DoctorId);
                            _notyf.Success("LogIn successfully", 3);
                            //_notyf.Information("Go To Attendance and Check-In Please");
                            return RedirectToAction("Index", "DoctorDashboard");
                        }
                    case 3:
                        {
                            HttpContext.Session.SetInt32("PatientId", (int)Auth.PatientId);
                            _notyf.Success("LogIn successfully", 3);
                            return RedirectToAction("Index", "Home");
                        }
                }
            }
            else
            {
                _notyf.Error("Username or password is incorrect", 3);
                return RedirectToAction("Login", "Auth");
            }
            return View();
        }


        //Get
        public IActionResult Register()
        {
            //General site info
            ViewBag.siteName = _context.HeadSections.FirstOrDefault().ClinicName;
            ViewBag.siteEmail = _context.HeadSections.FirstOrDefault().ClinicEmail;
            ViewBag.siteAddress = _context.HeadSections.FirstOrDefault().ClinicAddress;
            ViewBag.siteLogo = _context.HeadSections.FirstOrDefault().ImagePath;
            ViewBag.EmaegencyCase = _context.FeaturesSections.FirstOrDefault().EmaegencyCase;

            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register([Bind("Id,FirstName,LastName,Email,Gender,Address,Phone,ImagePath,ImageFile,Bod")] Patient patient, string password)
        {
            if (ModelState.IsValid)
            {
                if (patient.ImageFile != null)
                {
                    string wwwRootPath = _webHostEnviroment.WebRootPath;
                    string fileName = Guid.NewGuid().ToString() + "_" + patient.ImageFile.FileName;
                    //string extension = Path.GetExtension(category.ImageFile.FileName);
                    string path = Path.Combine(wwwRootPath + "/Attachments/PatientsAttachments/", fileName);
                    using (var fileStream = new FileStream(path, FileMode.Create))
                    {
                        await patient.ImageFile.CopyToAsync(fileStream);
                    }
                    patient.ImagePath = fileName;
                }

                var checkEmail = _context.Users.Any(u => u.UserName == patient.Email);
                if (!checkEmail)
                {
                    _context.Add(patient);
                    await _context.SaveChangesAsync();

                    var LastId = _context.Patients.OrderByDescending(p => p.Id).FirstOrDefault().Id;
                    var LaseEmail = _context.Patients.OrderByDescending(p => p.Id).FirstOrDefault().Email;
                    User newuser = new User();
                    newuser.UserName = LaseEmail;
                    newuser.Password = password;
                    newuser.RoleId = 3;
                    newuser.PatientId = LastId;
                    _context.Add(newuser);
                    await _context.SaveChangesAsync();

                    PatientsVesa pv = new PatientsVesa();
                    pv.PatientId = LastId;
                    pv.Balance = 100;
                    _context.Add(pv);
                    await _context.SaveChangesAsync();

                    _notyf.Success("Register Successfuly", 3);
                    _notyf.Information("Please Enter Your Email And Password To LogIn", 5);
                    return RedirectToAction("Login", "Auth");

                }
                else
                {
                    _notyf.Error("This Email already exists", 4);
                    return RedirectToAction("Register", "Auth");
                }
            }
            return RedirectToAction("Register", "Auth");
        }


    }
}

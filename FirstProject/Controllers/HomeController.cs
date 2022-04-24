using AspNetCoreHero.ToastNotification.Abstractions;
using FirstProject.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace FirstProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ModelContext _context;
        private readonly IWebHostEnvironment _webHostEnviroment;
        private readonly INotyfService _notyf;

        public HomeController(ILogger<HomeController> logger,ModelContext context, IWebHostEnvironment webHostEnviroment, INotyfService notyf)
        {
            _logger = logger;
            _context = context;
            _webHostEnviroment = webHostEnviroment;
            _notyf = notyf;
        }
		
		/*------------------------------- Index ------------------------------------------*/
        public async Task<IActionResult> IndexAsync()
        {
            //This For Session
            var checkPatient = HttpContext.Session.GetInt32("PatientId");
            if (checkPatient != null)
            {
                var PatienInformation = await _context.Patients.FindAsync((decimal)checkPatient);
                ViewBag.PatientId = checkPatient;
                ViewBag.PatientName = PatienInformation.FirstName;
                ViewBag.PatientIamge = PatienInformation.ImagePath;
            }
            //General site info
            ViewBag.siteName = _context.HeadSections.FirstOrDefault().ClinicName;
            ViewBag.siteEmail = _context.HeadSections.FirstOrDefault().ClinicEmail;
            ViewBag.siteAddress = _context.HeadSections.FirstOrDefault().ClinicAddress;
            ViewBag.siteLogo = _context.HeadSections.FirstOrDefault().ImagePath;

            //This For Banner Section
            ViewBag.BannerT = _context.BannerSections.FirstOrDefault().Title;
            ViewBag.Image = _context.BannerSections.FirstOrDefault().ImagePath;
            ViewBag.description = _context.BannerSections.FirstOrDefault().Description;

            //This For Features Section
            ViewBag.TimeForSun_Wed = _context.FeaturesSections.FirstOrDefault().TimesunWed;
            ViewBag.TimeForThu_Fri = _context.FeaturesSections.FirstOrDefault().TimethuFri;
            ViewBag.TimeForSat_Sun = _context.FeaturesSections.FirstOrDefault().TimesatSun;
            ViewBag.EmaegencyCase = _context.FeaturesSections.FirstOrDefault().EmaegencyCase;

            //This For Counter Section
            ViewBag.HappyPeople = _context.CounterSections.FirstOrDefault().HappyPeopel;
            ViewBag.SurgeryComepleted = _context.CounterSections.FirstOrDefault().SurgeryComeplet;
            ViewBag.ExpertDoctors = _context.CounterSections.FirstOrDefault().ExpertDoctor;
            ViewBag.WorldwideBranch = _context.CounterSections.FirstOrDefault().WordwideBranch;

            //This For Partners Section
            ViewBag.itemP = await _context.PartnersSections.ToListAsync();

            //This For Testimonial
            ViewBag.itemT = await _context.TestimonialSections.Include(t => t.Patient).ToListAsync();


            ViewData["DepartmentId"] = new SelectList(_context.Departments, "Id", "Name");
            return View();
        }
		
		/*------------------------------- About ------------------------------------------*/
        public async Task<IActionResult> AboutAsync()
        {
            //This Foe Session
            var checkPatient = HttpContext.Session.GetInt32("PatientId");
            if (checkPatient != null)
            {
                var PatienInformation = await _context.Patients.FindAsync((decimal)checkPatient);
                ViewBag.PatientId = checkPatient;
                ViewBag.PatientName = PatienInformation.FirstName;
                ViewBag.PatientIamge = PatienInformation.ImagePath;
            }
            //General site info
            ViewBag.siteName = _context.HeadSections.FirstOrDefault().ClinicName;
            ViewBag.siteEmail = _context.HeadSections.FirstOrDefault().ClinicEmail;
            ViewBag.siteAddress = _context.HeadSections.FirstOrDefault().ClinicAddress;
            ViewBag.siteLogo = _context.HeadSections.FirstOrDefault().ImagePath;
            ViewBag.EmaegencyCase = _context.FeaturesSections.FirstOrDefault().EmaegencyCase;

            //This For Testimonial
            ViewBag.itemT2 = await _context.TestimonialSections.Include(t => t.Patient).ToListAsync();

            return View(); 
        }     
		
		/*------------------------------- Service ------------------------------------------*/
        public async Task<IActionResult> ServiceAsync()
        {
            //This Foe Session
            var checkPatient = HttpContext.Session.GetInt32("PatientId");
            if (checkPatient != null)
            {
                var PatienInformation = await _context.Patients.FindAsync((decimal)checkPatient);
                ViewBag.PatientId = checkPatient;
                ViewBag.PatientName = PatienInformation.FirstName;
                ViewBag.PatientIamge = PatienInformation.ImagePath;
            }
            //General site info
            ViewBag.siteName = _context.HeadSections.FirstOrDefault().ClinicName;
            ViewBag.siteEmail = _context.HeadSections.FirstOrDefault().ClinicEmail;
            ViewBag.siteAddress = _context.HeadSections.FirstOrDefault().ClinicAddress;
            ViewBag.siteLogo = _context.HeadSections.FirstOrDefault().ImagePath;
            ViewBag.EmaegencyCase = _context.FeaturesSections.FirstOrDefault().EmaegencyCase;

            //This For Services
            ViewBag.itemService = await _context.ServicePages.ToListAsync();

            return View();
        }

		/*------------------------------- Department ------------------------------------------*/
        public async Task<IActionResult> DepartmentAsync()
        {
            //This Foe Session
            var checkPatient = HttpContext.Session.GetInt32("PatientId");
            if (checkPatient != null)
            {
                var PatienInformation = await _context.Patients.FindAsync((decimal)checkPatient);
                ViewBag.PatientId = checkPatient;
                ViewBag.PatientName = PatienInformation.FirstName;
                ViewBag.PatientIamge = PatienInformation.ImagePath;
            }
            //General site info
            ViewBag.siteName = _context.HeadSections.FirstOrDefault().ClinicName;
            ViewBag.siteEmail = _context.HeadSections.FirstOrDefault().ClinicEmail;
            ViewBag.siteAddress = _context.HeadSections.FirstOrDefault().ClinicAddress;
            ViewBag.siteLogo = _context.HeadSections.FirstOrDefault().ImagePath;
            ViewBag.EmaegencyCase = _context.FeaturesSections.FirstOrDefault().EmaegencyCase;

            //This For Department
            ViewBag.itemDepartment = await _context.Departments.ToListAsync();
            return View(); 
        }
		
		/*------------------------------- Doctor ------------------------------------------*/
        public async Task<IActionResult> DoctorAsync()
        {
            //This Foe Session
            var checkPatient = HttpContext.Session.GetInt32("PatientId");
            if (checkPatient != null)
            {
                var PatienInformation = await _context.Patients.FindAsync((decimal)checkPatient);
                ViewBag.PatientId = checkPatient;
                ViewBag.PatientName = PatienInformation.FirstName;
                ViewBag.PatientIamge = PatienInformation.ImagePath;
            }
            //General site info
            ViewBag.siteName = _context.HeadSections.FirstOrDefault().ClinicName;
            ViewBag.siteEmail = _context.HeadSections.FirstOrDefault().ClinicEmail;
            ViewBag.siteAddress = _context.HeadSections.FirstOrDefault().ClinicAddress;
            ViewBag.siteLogo = _context.HeadSections.FirstOrDefault().ImagePath;
            ViewBag.EmaegencyCase = _context.FeaturesSections.FirstOrDefault().EmaegencyCase;

            //This For Department
            ViewBag.GetDepartment = await _context.Departments.ToListAsync();
            //This For Doctor
            ViewBag.GetDoctor = await _context.Doctors.Include(d => d.Department).Include(d => d.Specialization).ToListAsync();
            return View();
        }
		
		/*------------------------------- Appoinment ------------------------------------------*/
        public async Task<IActionResult> AppoinmentAsync()
        {
            //This Foe Session
            var checkPatient = HttpContext.Session.GetInt32("PatientId");
            if (checkPatient != null)
            {
                var PatienInformation = await _context.Patients.FindAsync((decimal)checkPatient);
                ViewBag.PatientId = checkPatient;
                ViewBag.PatientName = PatienInformation.FirstName;
                ViewBag.PatientIamge = PatienInformation.ImagePath;
            }
            //General site info
            ViewBag.siteName = _context.HeadSections.FirstOrDefault().ClinicName;
            ViewBag.siteEmail = _context.HeadSections.FirstOrDefault().ClinicEmail;
            ViewBag.siteAddress = _context.HeadSections.FirstOrDefault().ClinicAddress;
            ViewBag.siteLogo = _context.HeadSections.FirstOrDefault().ImagePath;
            ViewBag.EmaegencyCase = _context.FeaturesSections.FirstOrDefault().EmaegencyCase;

            //To Get DeDepartmen
            ViewData["DepartmentId"] = new SelectList(_context.Departments, "Id", "Name");
            //To Get Site phone
            ViewBag.CallUs = _context.FeaturesSections.FirstOrDefault().EmaegencyCase;

            return View();
        }
        //To Get Doctor after filter
        [HttpGet]
        public JsonResult GetDoctor(int id)
        {
            var getdoctor = _context.Doctors.Where(x => x.DepartmentId == id).ToListAsync();

            return Json(getdoctor);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Appoinment([Bind("Id,AppointmentDate,AppointmentTime,Message,DepartmentId,DoctorId,PatientId,Status")] Appointment appointment, string CreditCard, decimal amount)
        {
            if (ModelState.IsValid)
            {
                var CheckBalance = _context.PatientsVesas.Where(x => x.PatientId == appointment.PatientId).FirstOrDefault();
                
                if(CheckBalance.Balance >= 0)
                {
                    //Save in appointment Table
                    _context.Add(appointment);
                    await _context.SaveChangesAsync();

                    var LastDoctorId = _context.Appointments.OrderByDescending(p => p.Id).FirstOrDefault().DoctorId;
                    var LastPatientId = _context.Appointments.OrderByDescending(p => p.Id).FirstOrDefault().PatientId;

                    //To Add Value in invoice
                    Invoice invoice = new Invoice();
                    invoice.CardNumber = CreditCard;
                    invoice.BookingDate = DateTime.Now.ToLongDateString();
                    invoice.BookingAmount = amount;
                    invoice.DoctorId = LastDoctorId;
                    invoice.PatientId = LastPatientId;
                    _context.Add(invoice);
                    await _context.SaveChangesAsync();

                    //To Update Value in PatientVesa
                    CheckBalance.Balance -= 10;
                    _context.Update(CheckBalance);
                    await _context.SaveChangesAsync();

                    return RedirectToAction("Confirmation", "Home");
                }

                _notyf.Error("You don't have enough money To Pay", 3);
                return RedirectToAction("Index", "Home");
            }
            ViewData["DepartmentId"] = new SelectList(_context.Departments, "Id", "Name", appointment.DepartmentId);
            return RedirectToAction("Appoinment", "Home");
        }
        public async Task<IActionResult> ConfirmationAsync()
        {
            //This Foe Session
            var checkPatient = HttpContext.Session.GetInt32("PatientId");
            if (checkPatient != null)
            {
                var PatienInformation = await _context.Patients.FindAsync((decimal)checkPatient);
                ViewBag.PatientId = checkPatient;
                ViewBag.PatientName = PatienInformation.FirstName;
                ViewBag.PatientIamge = PatienInformation.ImagePath;
            }

            //General site info
            ViewBag.siteName = _context.HeadSections.FirstOrDefault().ClinicName;
            ViewBag.siteEmail = _context.HeadSections.FirstOrDefault().ClinicEmail;
            ViewBag.siteAddress = _context.HeadSections.FirstOrDefault().ClinicAddress;
            ViewBag.siteLogo = _context.HeadSections.FirstOrDefault().ImagePath;
            ViewBag.EmaegencyCase = _context.FeaturesSections.FirstOrDefault().EmaegencyCase;

            _notyf.Success("The reservation was successful submit", 3);
            return View();
        }

		/*------------------------------- Contact ------------------------------------------*/
        public async Task<IActionResult> ContactAsync()
        {
            //This Foe Session
            var checkPatient = HttpContext.Session.GetInt32("PatientId");
            if (checkPatient != null)
            {
                var PatienInformation = await _context.Patients.FindAsync((decimal)checkPatient);
                ViewBag.PatientId = checkPatient;
                ViewBag.PatientName = PatienInformation.FirstName;
                ViewBag.PatientIamge = PatienInformation.ImagePath;
            }

            //General site info
            ViewBag.siteName = _context.HeadSections.FirstOrDefault().ClinicName;
            ViewBag.siteEmail = _context.HeadSections.FirstOrDefault().ClinicEmail;
            ViewBag.siteAddress = _context.HeadSections.FirstOrDefault().ClinicAddress;
            ViewBag.siteLogo = _context.HeadSections.FirstOrDefault().ImagePath;
            ViewBag.EmaegencyCase = _context.FeaturesSections.FirstOrDefault().EmaegencyCase;

            //This For Change email/phone/etc
            ViewBag.mailUsC = _context.HeadSections.FirstOrDefault().ClinicEmail;
            ViewBag.LocationC = _context.HeadSections.FirstOrDefault().ClinicAddress;
            ViewBag.Callus = _context.FeaturesSections.FirstOrDefault().EmaegencyCase;

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Contact([Bind("Id,FullName,Email,Topic,Phone,Message")] Contact contact)
        {
            if (ModelState.IsValid)
            {
                _context.Add(contact);
                await _context.SaveChangesAsync();
                _notyf.Success("Data Was Sent Successfuly", 3);
                return RedirectToAction("Contact", "Home");
            }
            return RedirectToAction("Contact", "Home");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        /*------------------------------- Search ------------------------------------------*/
        public async Task<IActionResult> SearchAsync()
        {
            //This Foe Session
            var checkPatient = HttpContext.Session.GetInt32("PatientId");
            if (checkPatient != null)
            {
                var PatienInformation = await _context.Patients.FindAsync((decimal)checkPatient);
                ViewBag.PatientId = checkPatient;
                ViewBag.PatientName = PatienInformation.FirstName;
                ViewBag.PatientIamge = PatienInformation.ImagePath;
            }

            //General site info
            ViewBag.siteName = _context.HeadSections.FirstOrDefault().ClinicName;
            ViewBag.siteEmail = _context.HeadSections.FirstOrDefault().ClinicEmail;
            ViewBag.siteAddress = _context.HeadSections.FirstOrDefault().ClinicAddress;
            ViewBag.siteLogo = _context.HeadSections.FirstOrDefault().ImagePath;
            ViewBag.EmaegencyCase = _context.FeaturesSections.FirstOrDefault().EmaegencyCase;
            
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Search(string SearchFor)
        {
            var checkPatient = HttpContext.Session.GetInt32("PatientId");
            if (checkPatient != null)
            {
                var PatienInformation = await _context.Patients.FindAsync((decimal)checkPatient);
                ViewBag.PatientId = checkPatient;
                ViewBag.PatientName = PatienInformation.FirstName;
                ViewBag.PatientIamge = PatienInformation.ImagePath;
            }

            //General site info
            ViewBag.siteName = _context.HeadSections.FirstOrDefault().ClinicName;
            ViewBag.siteEmail = _context.HeadSections.FirstOrDefault().ClinicEmail;
            ViewBag.siteAddress = _context.HeadSections.FirstOrDefault().ClinicAddress;
            ViewBag.siteLogo = _context.HeadSections.FirstOrDefault().ImagePath;
            ViewBag.EmaegencyCase = _context.FeaturesSections.FirstOrDefault().EmaegencyCase;

            if (SearchFor != null)
            {
                SearchFor = SearchFor.ToLower();
                ViewBag.GetDoctorResult = await _context.Doctors.Where(x => x.FirstName.ToLower().Contains(SearchFor)).Include(d => d.Specialization).ToListAsync();
                ViewBag.GetClinicResult = await _context.Departments.Where(x => x.Name.ToLower().Contains(SearchFor)).ToListAsync();
                if (ViewBag.GetDoctorResult.Count <= 0 && ViewBag.GetClinicResult.Count <=0 )
                {
                    _notyf.Information("No Result Found");
                    return RedirectToAction("Search", "Home");
                }

                return View();
            }
            _notyf.Information("Type somthing To search");
            return RedirectToAction("Search", "Home");
        }


        /*------------------------------- PatienInvoices ------------------------------------------*/
        //To get the Invoices
        public async Task<IActionResult> PatienInvoicesAsync(decimal? id)
        {
            //This Foe Session
            var checkPatient = HttpContext.Session.GetInt32("PatientId");
            if (checkPatient != null)
            {
                var PatienInformation = await _context.Patients.FindAsync((decimal)checkPatient);
                ViewBag.PatientId = checkPatient;
                ViewBag.PatientName = PatienInformation.FirstName;
                ViewBag.PatientIamge = PatienInformation.ImagePath;

                //General site info
                ViewBag.siteName = _context.HeadSections.FirstOrDefault().ClinicName;
                ViewBag.siteEmail = _context.HeadSections.FirstOrDefault().ClinicEmail;
                ViewBag.siteAddress = _context.HeadSections.FirstOrDefault().ClinicAddress;
                ViewBag.siteLogo = _context.HeadSections.FirstOrDefault().ImagePath;
                ViewBag.EmaegencyCase = _context.FeaturesSections.FirstOrDefault().EmaegencyCase;

                if(id != checkPatient)
                {
                    return NotFound();
                }

                var modelContext = _context.Invoices.Where(x => x.PatientId == id).Include(i => i.Doctor).Include(i => i.Patient);
                return View(await modelContext.ToListAsync());
            }
            return RedirectToAction("Page404", "Home");


        }

        /*------------------------------- PatienProfile ------------------------------------------*/
        public async Task<IActionResult> PatienProfileAsync(decimal? id)
        {
            //This Foe Session
            var checkPatient = HttpContext.Session.GetInt32("PatientId");
            if (checkPatient != null)
            {
                var PatienInformation = await _context.Patients.FindAsync((decimal)checkPatient);
                ViewBag.PatientId = checkPatient;
                ViewBag.PatientName = PatienInformation.FirstName;
                ViewBag.PatientIamge = PatienInformation.ImagePath;

                //General site info
                ViewBag.siteName = _context.HeadSections.FirstOrDefault().ClinicName;
                ViewBag.siteEmail = _context.HeadSections.FirstOrDefault().ClinicEmail;
                ViewBag.siteAddress = _context.HeadSections.FirstOrDefault().ClinicAddress;
                ViewBag.siteLogo = _context.HeadSections.FirstOrDefault().ImagePath;
                ViewBag.EmaegencyCase = _context.FeaturesSections.FirstOrDefault().EmaegencyCase;

                var patient = await _context.Patients.FindAsync(id);
                if (patient.Id != checkPatient)
                {
                    return NotFound();
                }
                return View(patient);
            }

            return RedirectToAction("Page404", "Home");


        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> PatienProfile(decimal id, [Bind("Id,FirstName,LastName,Email,Gender,Address,Phone,ImagePath,ImageFile,Bod")] Patient patient, string password, string newpassword, string renewpassword)
        {
            var checkPatient = HttpContext.Session.GetInt32("PatientId");
            ViewBag.PatientId = checkPatient;

            if (id != patient.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (password != null)
                    { 
                        var user = _context.Users.Where(u => u.PatientId == id).FirstOrDefault();
                        if (user == null)
                        {
                            _notyf.Success("user not found", 3);
                            return RedirectToAction("PatienProfile", "Home");
                        }
                        else
                        {
                            if (user.Password == password)
                            {
                                if (newpassword == renewpassword)
                                {
                                    user.Password = newpassword;
                                    _context.Update(user);
                                    await _context.SaveChangesAsync();
                                    _notyf.Success("Password Change Successfuly", 3);
                                    return RedirectToAction("PatienProfile", "Home");
                                }
                                else
                                {
                                    _notyf.Warning("Newpassword and Confirm Password Dosnt mach", 3);
                                    return RedirectToAction("PatienProfile", "Home");
                                }
                            }
                            else
                            {
                                _notyf.Warning("The Current Password Dosnt Correct", 3);
                                return RedirectToAction("PatienProfile", "Home");
                            }
                        }
                    }

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

                    _context.Update(patient);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PatientExists(patient.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                _notyf.Success("Information Edit Successfuly", 3);
                return RedirectToAction("PatienProfile", "Home");
            }
            _notyf.Error("Information Edit Successfuly", 3);
            return View(patient);
        }
        private bool PatientExists(decimal id)
        {
            return _context.Patients.Any(e => e.Id == id);
        }

        /*------------------------------- FeedBake ------------------------------------------*/
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> FeedBake([Bind("Id,Subject,Description,PatientId,Status")] TestimonialSection testimonialSection, decimal PId, string subject, string description)
        {
            var checkPatient = HttpContext.Session.GetInt32("PatientId");
            if (checkPatient != null)
            {
                var PatienInformation = await _context.Patients.FindAsync((decimal)checkPatient);
                ViewBag.PatientId = checkPatient;
                ViewBag.PatientName = PatienInformation.FirstName;
                ViewBag.PatientIamge = PatienInformation.ImagePath;

                //General site info
                ViewBag.siteName = _context.HeadSections.FirstOrDefault().ClinicName;
                ViewBag.siteEmail = _context.HeadSections.FirstOrDefault().ClinicEmail;
                ViewBag.siteAddress = _context.HeadSections.FirstOrDefault().ClinicAddress;
                ViewBag.siteLogo = _context.HeadSections.FirstOrDefault().ImagePath;
                ViewBag.EmaegencyCase = _context.FeaturesSections.FirstOrDefault().EmaegencyCase;

                if (ModelState.IsValid)
                {
                    testimonialSection.Status = "0";
                    testimonialSection.PatientId = PId;
                    testimonialSection.Subject = subject;
                    testimonialSection.Description = description;
                    _context.Add(testimonialSection);
                    await _context.SaveChangesAsync();
                    _notyf.Success("Thanks For Your FeedBake", 3);
                    return Redirect(Request.Headers["Referer"].ToString());
                }
                _notyf.Success("Somthing wont Wrong Please Try Agin Later", 3);
                return View(testimonialSection);
            }
            return RedirectToAction("Page404", "Home");
        }


        /*------------------------------- Page404 ------------------------------------------*/
        //This For Logout
        public IActionResult Page404()
        {
            _notyf.Error("You don't have no permission to access this page");
            return View();
        }


        /*------------------------------- LogOut ------------------------------------------*/
        //This For Logout
        public IActionResult LogOut()
        {
            HttpContext.Session.Remove("PatientId");
            _notyf.Success("Logout successfully", 3);
            return RedirectToAction("Login", "Auth");
        }
    }
}

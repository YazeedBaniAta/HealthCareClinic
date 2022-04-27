using AspNetCoreHero.ToastNotification.Abstractions;
using FirstProject.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace FirstProject.Controllers
{
    public class AdminDashboardController : Controller
    {
        private readonly ModelContext _context;
        private readonly IWebHostEnvironment _webHostEnviroment;
        private readonly INotyfService _notyf;
        public AdminDashboardController(ModelContext context, IWebHostEnvironment webHostEnviroment, INotyfService notyf)
        {
            _context = context;
            _webHostEnviroment = webHostEnviroment;
            _notyf = notyf;
        }
        public async Task<IActionResult> Index()
        {
            var checkAdmin = HttpContext.Session.GetInt32("AdminId");
            if (checkAdmin != null)
            {
                var AdminInformation = await _context.Admins.FindAsync((decimal)checkAdmin);
                ViewBag.AdminId = checkAdmin;
                ViewBag.AdminName = AdminInformation.FirstName;
                ViewBag.AdminIamge = AdminInformation.ImagePath;

                ViewBag.clinicsCount = _context.Departments.Count();
                ViewBag.doctorsCount = _context.Doctors.Count();
                ViewBag.patientsCount = _context.Patients.Count();
                ViewBag.usersCount = _context.Users.Count();

                ViewBag.LastDoctors =  _context.Doctors.OrderByDescending(u=>u.Id).Include(u=>u.Department).Include(u => u.Specialization).Take(5).ToList();
                ViewBag.Lastpatients =  _context.Patients.OrderByDescending(u=>u.Id).Take(5).ToList();
                ViewBag.Lastappointment = _context.Appointments.OrderByDescending(u => u.Id).Include(u=>u.Patient).Include(u => u.Doctor).Take(5).ToList();
                
                return View();
            }
            return RedirectToAction("Page404", "Home");
        }
		
		/*------------------------------- Profile ------------------------------------------*/
        public async Task<IActionResult> ProfileAsync(decimal? id)
        {
            if (id == null) { return NotFound(); }
            var checkAdmin = HttpContext.Session.GetInt32("AdminId");
            if (checkAdmin != null)
            {
                var AdminInformation = await _context.Admins.FindAsync((decimal)checkAdmin);
                ViewBag.AdminId = checkAdmin;
                ViewBag.AdminName = AdminInformation.FirstName;
                ViewBag.AdminIamge = AdminInformation.ImagePath;
                if (checkAdmin !=id)
                {
                    return NotFound();
                }

                var admin = await _context.Admins.FindAsync(id);
                if (admin == null) { return NotFound(); }
                if (admin.Id != checkAdmin)
                {
                    _notyf.Error("You don't have no permission to access this page");
                    return NotFound();
                }

                return View(admin);
            }
			
            return RedirectToAction("Page404", "Home");   
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Profile(decimal id, [Bind("Id,FirstName,LastName,Phone,ImagePath,ImageFile")] Admin admin, string password, string newpassword, string renewpassword)
        {
            var checkAdmin = HttpContext.Session.GetInt32("AdminId");
            ViewBag.AdminId = checkAdmin;
            if (id != admin.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (password != null)
                    {
                        //_context.Update(admin);
                        //await _context.SaveChangesAsync();
                        // _context.Doctors.Where(x => x.DepartmentId == id).FirstOrDefault().FirstName;
                        var user = _context.Users.Where(u => u.AdminId == id).FirstOrDefault();
                        if (user == null)
                        {
                            _notyf.Success("user not found",3);
                            return RedirectToAction("Profile", "AdminDashboard");
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
                                    return RedirectToAction("Profile", "AdminDashboard");
                                }
                                else
                                {
                                    _notyf.Warning("Newpassword and Confirm Password Dosnt mach", 3);
                                    return RedirectToAction("Profile", "AdminDashboard");
                                }
                            }
                            else
                            {
                                _notyf.Warning("The Current Password Dosnt Correct", 3);
                                return RedirectToAction("Profile", "AdminDashboard");
                            }
                        }
                    }
                    if (admin.ImageFile != null)
                    {
                        string wwwRootPath = _webHostEnviroment.WebRootPath;
                        string fileName = Guid.NewGuid().ToString() + "_" + admin.ImageFile.FileName;
                        //string extension = Path.GetExtension(category.ImageFile.FileName);
                        string path = Path.Combine(wwwRootPath + "/Attachments/AdminAttachments/", fileName);
                        using (var fileStream = new FileStream(path, FileMode.Create))
                        {
                            await admin.ImageFile.CopyToAsync(fileStream);
                        }
                        admin.ImagePath = fileName;
                    }

                    _context.Update(admin);
                    await _context.SaveChangesAsync();


                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AdminExists(admin.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                _notyf.Success("Profile Edit Success");
                return RedirectToAction("Profile", "AdminDashboard");
            }
            return View(admin);
        }
        private bool AdminExists(decimal id)
        {
            return _context.Admins.Any(e => e.Id == id);
        }

		/*------------------------------- Doctor Report ------------------------------------------*/        
        public async Task<IActionResult> DoctorReportAsync()
        {
            var checkAdmin = HttpContext.Session.GetInt32("AdminId");
            if (checkAdmin != null)
            {
                var AdminInformation = await _context.Admins.FindAsync((decimal)checkAdmin);
                ViewBag.AdminId = checkAdmin;
                ViewBag.AdminName = AdminInformation.FirstName;
                ViewBag.AdminIamge = AdminInformation.ImagePath;

                ViewData["DepartmentId"] = new SelectList(_context.Departments, "Id", "Name");

                var modelContext = _context.Doctors.Include(d => d.Department).Include(d => d.Specialization);
                return View(await modelContext.ToListAsync());
            }

            return RedirectToAction("Page404", "Home");
        }

        [HttpPost]
        public async Task<IActionResult> DoctorReport(decimal? SearchDepartment)
        {
            var checkAdmin = HttpContext.Session.GetInt32("AdminId");
            if (checkAdmin != null)
            {
                var AdminInformation = await _context.Admins.FindAsync((decimal)checkAdmin);
                ViewBag.AdminId = checkAdmin;
                ViewBag.AdminName = AdminInformation.FirstName;
                ViewBag.AdminIamge = AdminInformation.ImagePath;
                ViewData["DepartmentId"] = new SelectList(_context.Departments, "Id", "Name");
                if(SearchDepartment == null)
                {
                    var modelContext = _context.Doctors.Include(d => d.Department).Include(d => d.Specialization);
                    return View(await modelContext.ToListAsync());
                }
                var Result = await _context.Doctors.Where(x => x.DepartmentId == SearchDepartment).Include(d => d.Department).Include(d => d.Specialization).ToListAsync();
                return View(Result);
            }

            return RedirectToAction("Page404", "Home");
        }

        /*------------------------------- Patient Report ------------------------------------------*/
        public async Task<IActionResult> PatientReportAsync()
        {
            var checkAdmin = HttpContext.Session.GetInt32("AdminId");
            if (checkAdmin != null)
            {
                var AdminInformation = await _context.Admins.FindAsync((decimal)checkAdmin);
                ViewBag.AdminId = checkAdmin;
                ViewBag.AdminName = AdminInformation.FirstName;
                ViewBag.AdminIamge = AdminInformation.ImagePath;
                return View(await _context.Patients.ToListAsync());
            }

            return RedirectToAction("Page404", "Home");
        }
		
		/*------------------------------- Appointment Report ------------------------------------------*/ 
        public async Task<IActionResult> AppointmentReportAsync()
        {
            var checkAdmin = HttpContext.Session.GetInt32("AdminId");
            if (checkAdmin != null)
            {
                var AdminInformation = await _context.Admins.FindAsync((decimal)checkAdmin);
                ViewBag.AdminId = checkAdmin;
                ViewBag.AdminName = AdminInformation.FirstName;
                ViewBag.AdminIamge = AdminInformation.ImagePath;
                ViewData["DoctorId"] = new SelectList(_context.Doctors, "Id", "FirstName");
            var modelContext = _context.Appointments.Include(a => a.Department).Include(a => a.Doctor).Include(a => a.Patient);
                return View(await modelContext.ToListAsync());
            }

            return RedirectToAction("Page404", "Home");
        }

        [HttpPost]
        public async Task<IActionResult> AppointmentReport(decimal? DoctorId, DateTime SearchFrom, DateTime SearchTo)
        {
            var checkAdmin = HttpContext.Session.GetInt32("AdminId");
            if (checkAdmin != null)
            {
                var AdminInformation = await _context.Admins.FindAsync((decimal)checkAdmin);
                ViewBag.AdminId = checkAdmin;
                ViewBag.AdminName = AdminInformation.FirstName;
                ViewBag.AdminIamge = AdminInformation.ImagePath;

                ViewData["DoctorId"] = new SelectList(_context.Doctors, "Id", "FirstName");
                var modelContext = _context.Appointments.Include(a => a.Department).Include(a => a.Doctor).Include(a => a.Patient);

                if(SearchFrom == null && SearchTo == null & DoctorId == null)
                {
                    return View( await modelContext.ToListAsync());
                }

                if (SearchFrom != null && SearchTo == null & DoctorId == null)
                {
                    var Result = await modelContext.Where(x => x.AppointmentDate.Value.Date == SearchFrom).ToListAsync();
                    return View(Result);
                }
                else if (SearchFrom != null && SearchTo != null && DoctorId == null)
                {
                    var Result = await modelContext.Where(x => x.AppointmentDate.Value.Date >= SearchFrom && x.AppointmentDate.Value.Date <= SearchTo).ToListAsync();
                    return View(Result);
                }
                else if (SearchFrom != null && SearchTo == null && DoctorId != null)
                {
                    var Result = await modelContext.Where(x => x.DoctorId == DoctorId && x.AppointmentDate.Value.Date == SearchFrom).ToListAsync();
                    return View(Result);
                }
                else if (SearchFrom != null && SearchTo != null && DoctorId != null)
                {
                    var Result = await modelContext.Where(x => x.DoctorId == DoctorId && x.AppointmentDate.Value.Date >= SearchFrom && x.AppointmentDate.Value.Date <= SearchTo).ToListAsync();
                    return View(Result);
                }

                return RedirectToAction("AppointmentReport", "AdminDashboard");
            }

            return RedirectToAction("Page404", "Home");

        }

        /*------------------------------- Attendances Report ------------------------------------------*/
        public async Task<IActionResult> AttendancesReportAsync()
        {
            var checkAdmin = HttpContext.Session.GetInt32("AdminId");
            if (checkAdmin != null)
            {
                var AdminInformation = await _context.Admins.FindAsync((decimal)checkAdmin);
                ViewBag.AdminId = checkAdmin;
                ViewBag.AdminName = AdminInformation.FirstName;
                ViewBag.AdminIamge = AdminInformation.ImagePath;

                return View();
            }

            return RedirectToAction("Page404", "Home");
        }

        [HttpPost]
        public async Task<IActionResult> AttendancesReport(DateTime SearchFrom)
        {
            var checkAdmin = HttpContext.Session.GetInt32("AdminId");
            if (checkAdmin != null)
            {
                var AdminInformation = await _context.Admins.FindAsync((decimal)checkAdmin);
                ViewBag.AdminId = checkAdmin;
                ViewBag.AdminName = AdminInformation.FirstName;
                ViewBag.AdminIamge = AdminInformation.ImagePath;

                var Result = await _context.Attendances.Where(x => x.AttendanceDate == SearchFrom.ToShortDateString().ToString()).Include(a => a.Doctor).ToListAsync();

                return View(Result);
            }

            return RedirectToAction("Page404", "Home");
        }

        /*------------------------------- LogOut ------------------------------------------*/
        public IActionResult LogOut()
        {
            HttpContext.Session.Remove("AdminId");
            _notyf.Success("Logout successfully", 3);
            return RedirectToAction("Login", "Auth");
        }
    }
}

using AspNetCoreHero.ToastNotification.Abstractions;
using FirstProject.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Mail;
using Microsoft.AspNetCore.Http;

namespace FirstProject.Controllers
{
    public class DoctorDashboardController : Controller
    {
        private readonly ModelContext _context;
        private readonly IWebHostEnvironment _webHostEnviroment;
        private readonly INotyfService _notyf;

        public DoctorDashboardController(ModelContext context, IWebHostEnvironment webHostEnviroment, INotyfService notyf)
        {
            _context = context;
            _webHostEnviroment = webHostEnviroment;
            _notyf = notyf;
        }

        public async Task<IActionResult> IndexAsync()
        {
            var checkDoctor = HttpContext.Session.GetInt32("DoctorId");
            if (checkDoctor != null)
            {
                var DoctorInformation = await _context.Doctors.FindAsync((decimal)checkDoctor);
                ViewBag.DoctorId = checkDoctor;
                ViewBag.DoctorName = DoctorInformation.FirstName;
                ViewBag.DoctorIamge = DoctorInformation.ImagePath;

                ViewBag.Lastappointment = _context.Appointments.Where(u=> u.DoctorId == checkDoctor).OrderByDescending(u => u.Id).Include(u => u.Patient).Take(5).ToList();
                
                return View();
            }
            
            return RedirectToAction("Page404", "Home");
        }

        /*------------------------------- Attendances ------------------------------------------*/
        public async Task<IActionResult> AddAttendances(decimal? id)
        {
            var checkDoctor = HttpContext.Session.GetInt32("DoctorId");
            if (checkDoctor != null)
            {
                var DoctorInformation = await _context.Doctors.FindAsync((decimal)checkDoctor);
                ViewBag.DoctorId = checkDoctor;
                ViewBag.DoctorName = DoctorInformation.FirstName;
                ViewBag.DoctorIamge = DoctorInformation.ImagePath;
                
                if (checkDoctor != id )
                {
                    return NotFound();
                }

                var modelContext = await _context.Attendances.Where(x => x.DoctorId == id).Include(d => d.Doctor).ToListAsync();

                return View(modelContext);
            }
            
            return RedirectToAction("Page404", "Home");
            
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddAttendances(int DId, string CheckAttend)
        {
            if (ModelState.IsValid)
            {
                Attendance attendance = new Attendance();
                attendance.DoctorId = DId;
                attendance.Status = CheckAttend;
                attendance.AttendanceDate = DateTime.Now.ToShortDateString();
                _context.Add(attendance);
                await _context.SaveChangesAsync();
                _notyf.Success("Your successfully Checked-In", 3);
                return RedirectToAction("AddAttendances", "DoctorDashboard");
            }
            return RedirectToAction("AddAttendances", "DoctorDashboard");
        }


        /*------------------------------- Appointments ------------------------------------------*/
        public async Task<IActionResult> Appointments(decimal? id)
        {
            var checkDoctor = HttpContext.Session.GetInt32("DoctorId");
            if (checkDoctor != null)
            {
                var DoctorInformation = await _context.Doctors.FindAsync((decimal)checkDoctor);
                ViewBag.DoctorId = checkDoctor;
                ViewBag.DoctorName = DoctorInformation.FirstName;
                ViewBag.DoctorIamge = DoctorInformation.ImagePath;
                
                if (id != checkDoctor)
                {
                    return NotFound();
                }

                var modelContext = await _context.Appointments.Where(x => x.DoctorId == id).Include(a => a.Patient).ToListAsync();

                return View(modelContext);
            }
            
            return RedirectToAction("Page404", "Home");
            
        }
        
        public async Task<IActionResult> SearchAppointmentsAsync()
        {
            var checkDoctor = HttpContext.Session.GetInt32("DoctorId");
            if (checkDoctor != null)
            {
                var DoctorInformation = await _context.Doctors.FindAsync((decimal)checkDoctor);
                ViewBag.DoctorId = checkDoctor;
                ViewBag.DoctorName = DoctorInformation.FirstName;
                ViewBag.DoctorIamge = DoctorInformation.ImagePath;
                return View();
            }
            
            return RedirectToAction("Page404", "Home");
        }
        /*  
        *  SearchAppointments 
        */
        [HttpPost]
        public async Task<IActionResult> SearchAppointments(decimal? id, DateTime SearchFrom, DateTime SearchTo)
        {
            var checkDoctor = HttpContext.Session.GetInt32("DoctorId");
            if (checkDoctor != null)
            {
                var DoctorInformation = await _context.Doctors.FindAsync((decimal)checkDoctor);
                ViewBag.DoctorId = checkDoctor;
                ViewBag.DoctorName = DoctorInformation.FirstName;
                ViewBag.DoctorIamge = DoctorInformation.ImagePath;
				
				if(SearchFrom != null && SearchTo == null)
                {
					ViewBag.GetApp = await _context.Appointments.Where(x => x.DoctorId == id && x.AppointmentDate == SearchFrom).Include(a => a.Patient).ToListAsync();
				}
				else if(SearchFrom != null && SearchTo != null)
                {
					ViewBag.GetApp = await _context.Appointments.Where(x => x.DoctorId == id && x.AppointmentDate >= SearchFrom && x.AppointmentDate <= SearchTo).Include(a => a.Patient).ToListAsync();
				}
                
                if (ViewBag.GetApp != null)
                {
                    _notyf.Information("there's reservation in this period");
                    return View(ViewBag.GetApp);
                }

                _notyf.Success("there's no reservation in this period");
                return RedirectToAction("SearchAppointments", "DoctorDashboard");
            }
            
            return RedirectToAction("Page404", "Home");
            
            //return Redirect(Request.Headers["Referer"].ToString());
        }
        /*  
         *  AppointmentDetails 
         */
        public async Task<IActionResult> AppointmentDetails(decimal? id)
        {
            var checkDoctor = HttpContext.Session.GetInt32("DoctorId");
            if (checkDoctor != null)
            {
                var DoctorInformation = await _context.Doctors.FindAsync((decimal)checkDoctor);
                ViewBag.DoctorId = checkDoctor;
                ViewBag.DoctorName = DoctorInformation.FirstName;
                ViewBag.DoctorIamge = DoctorInformation.ImagePath;
                if (id == null)
                {
                    return NotFound();
                }
                var appointment = await _context.Appointments
                    .Include(a => a.Patient)
                    .FirstOrDefaultAsync(m => m.Id == id);
                if (appointment == null)
                {
                    return NotFound();
                }
                return View(appointment);
            }
           
            return RedirectToAction("Page404", "Home");
        }
        /*  
        *  EditAppointment 
        */
        public async Task<IActionResult> EditAppointment(decimal? id)
        {
            var checkDoctor = HttpContext.Session.GetInt32("DoctorId");
            if (checkDoctor != null)
            {
                var DoctorInformation = await _context.Doctors.FindAsync((decimal)checkDoctor);
                ViewBag.DoctorId = checkDoctor;
                ViewBag.DoctorName = DoctorInformation.FirstName;
                ViewBag.DoctorIamge = DoctorInformation.ImagePath;
                if (id == null)
                {
                    return NotFound();
                }

                var appointment = await _context.Appointments.FindAsync(id);
                if (appointment == null)
                {
                    return NotFound();
                }
                ViewData["DepartmentId"] = new SelectList(_context.Departments, "Id", "Name", appointment.DepartmentId);
                ViewData["DoctorId"] = new SelectList(_context.Doctors, "Id", "FirstName", appointment.DoctorId);
                ViewData["PatientId"] = new SelectList(_context.Patients, "Id", "FirstName", appointment.PatientId);
                return View(appointment);
            }
            
            return RedirectToAction("Page404", "Home"); 
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditAppointment(decimal id, [Bind("Id,AppointmentDate,AppointmentTime,Message,DepartmentId,DoctorId,PatientId,Status")] Appointment appointment)
        {
            var checkDoctor = HttpContext.Session.GetInt32("DoctorId");
            if (checkDoctor != null)
            {
                var DoctorInformation = await _context.Doctors.FindAsync((decimal)checkDoctor);
                ViewBag.DoctorId = checkDoctor;
                ViewBag.DoctorName = DoctorInformation.FirstName;
                ViewBag.DoctorIamge = DoctorInformation.ImagePath;

                if (id != appointment.Id)
                {
                    return NotFound();
                }

                if (ModelState.IsValid)
                {
                    try
                    {
                        _context.Update(appointment);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!AppointmentExists(appointment.Id))
                        {
                            return NotFound();
                        }
                        else
                        {
                            throw;
                        }
                    }
                    _notyf.Success("Information Edit Successfuly", 3);
                    return RedirectToAction("EditAppointment", "DoctorDashboard");
                }
                ViewData["DepartmentId"] = new SelectList(_context.Departments, "Id", "Name", appointment.DepartmentId);
                ViewData["DoctorId"] = new SelectList(_context.Doctors, "Id", "FirstName", appointment.DoctorId);
                ViewData["PatientId"] = new SelectList(_context.Patients, "Id", "FirstName", appointment.PatientId);
                return View(appointment);
            }

            return RedirectToAction("Page404", "Home");
        }
        private bool AppointmentExists(decimal id)
        {
            return _context.Appointments.Any(e => e.Id == id);
        }
        /*  
        *  SendEmail 
        */
        [HttpPost]
        public IActionResult SendEmail(string to, string subject, string body)
        {
            
            MailMessage message = new MailMessage();
            message.To.Add(to);
            message.Subject = subject;
            message.Body = body;
            message.From = new MailAddress("healthcareBAccoount@gmail.com");
            message.IsBodyHtml = false;
            SmtpClient smtp = new SmtpClient("smtp.gmail.com");
            smtp.Port = 587;
            smtp.UseDefaultCredentials = true;
            smtp.EnableSsl = true;
            smtp.Credentials = new System.Net.NetworkCredential("healthcareBAccoount@gmail.com", "Healthcare#1234");
            smtp.Send(message);

            _notyf.Success("Email Send Successfuly", 3);
            return Redirect(Request.Headers["Referer"].ToString());
        }


        /*------------------------------- Profile ------------------------------------------*/
        public async Task<IActionResult> DoctorProfileAsync(decimal? id)
        {
            var checkDoctor = HttpContext.Session.GetInt32("DoctorId");
            if (checkDoctor != null)
            {
                var DoctorInformation = await _context.Doctors.FindAsync((decimal)checkDoctor);
                ViewBag.DoctorId = checkDoctor;
                ViewBag.DoctorName = DoctorInformation.FirstName;
                ViewBag.DoctorIamge = DoctorInformation.ImagePath;
                if (id == null)
                {
                    return NotFound();
                }

                var doctor = await _context.Doctors.FindAsync(id);
                if(doctor == null) { return NotFound(); }
                if (doctor.Id != checkDoctor)
                {
                    _notyf.Error("You don't have no permission to access this page");
                    return NotFound();
                }
                return View(doctor);
            }
            
            return RedirectToAction("Page404", "Home");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DoctorProfile(decimal id, [Bind("Id,FirstName,LastName,Email,Phone,Address,Bod,IsAvailable,AvailableTime,AvailableDay,Salary,DepartmentId,SpecializationId,ImagePath,ImageFile")] Doctor doctor, string password, string newpassword, string renewpassword)
        {
            var checkDoctor = HttpContext.Session.GetInt32("DoctorId");
            ViewBag.DoctorId = checkDoctor;
            if (id != doctor.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (password != null)
                    {
                        var user = _context.Users.Where(u => u.DoctorId == id).FirstOrDefault();
                        if (user == null)
                        {
                            _notyf.Success("user not found",3);
                            return RedirectToAction("DoctorProfile", "DoctorDashboard");
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
                                    _notyf.Success("Password Change Successfuly",3);
                                    return RedirectToAction("DoctorProfile", "DoctorDashboard");
                                }
                                else
                                {
                                    _notyf.Warning("Newpassword and Confirm Password Dosnt mach",3);
                                    return RedirectToAction("DoctorProfile", "DoctorDashboard");
                                }
                            }
                            else
                            {
                                _notyf.Warning("The Current Password Dosnt Correct",3);
                                return RedirectToAction("DoctorProfile", "DoctorDashboard");
                            }
                        }
                    }
                    if (doctor.ImageFile != null)
                    {
                        string wwwRootPath = _webHostEnviroment.WebRootPath;
                        string fileName = Guid.NewGuid().ToString() + "_" + doctor.ImageFile.FileName;
                        //string extension = Path.GetExtension(category.ImageFile.FileName);
                        string path = Path.Combine(wwwRootPath + "/Attachments/DoctorAttachments/", fileName);
                        using (var fileStream = new FileStream(path, FileMode.Create))
                        {
                            await doctor.ImageFile.CopyToAsync(fileStream);
                        }
                        doctor.ImagePath = fileName;
                    }

                    _context.Update(doctor);
                    await _context.SaveChangesAsync();
 
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DoctorExists(doctor.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                _notyf.Success("Information Edit Successfuly", 3);
                return RedirectToAction("DoctorProfile", "DoctorDashboard");
            }
            ViewData["DepartmentId"] = new SelectList(_context.Departments, "Id", "Description", doctor.DepartmentId);
            ViewData["SpecializationId"] = new SelectList(_context.Specializations, "Id", "Id", doctor.SpecializationId);
            return View(doctor);
        }
        private bool DoctorExists(decimal id)
        {
            return _context.Doctors.Any(e => e.Id == id);
        }

        /*------------------------------- LogOut ------------------------------------------*/
        public IActionResult LogOut()
        {
            HttpContext.Session.Remove("DoctorId");
            _notyf.Success("Logout successfully", 3);
            return RedirectToAction("Login", "Auth");
        }


    }
}

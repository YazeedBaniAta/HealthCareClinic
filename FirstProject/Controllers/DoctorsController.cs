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
using System.Net.Mail;

namespace FirstProject.Controllers
{
    public class DoctorsController : Controller
    {
        private readonly ModelContext _context;
        private readonly IWebHostEnvironment _webHostEnviroment;
        private readonly INotyfService _notyf;

        public DoctorsController(ModelContext context, IWebHostEnvironment webHostEnviroment, INotyfService notyf)
        {
            _context = context;
            _webHostEnviroment = webHostEnviroment;
            _notyf = notyf;
        }

        // GET: Doctors
        public async Task<IActionResult> Index()
        {
            var checkAdmin = HttpContext.Session.GetInt32("AdminId");
            if (checkAdmin != null)
            {
                var AdminInformation = await _context.Admins.FindAsync((decimal)checkAdmin);
                ViewBag.AdminId = checkAdmin;
                ViewBag.AdminName = AdminInformation.FirstName;
                ViewBag.AdminIamge = AdminInformation.ImagePath;
                var modelContext = _context.Doctors.Include(d => d.Department).Include(d => d.Specialization);
                return View(await modelContext.ToListAsync());
            }
			
            return RedirectToAction("Page404", "Home");
        }

        // GET: Doctors/Details/5
        public async Task<IActionResult> Details(decimal? id)
        {
            var checkAdmin = HttpContext.Session.GetInt32("AdminId");
            if (checkAdmin != null)
            {
                var AdminInformation = await _context.Admins.FindAsync((decimal)checkAdmin);
                ViewBag.AdminId = checkAdmin;
                ViewBag.AdminName = AdminInformation.FirstName;
                ViewBag.AdminIamge = AdminInformation.ImagePath;
                if (id == null)
                {
                    return NotFound();
                }

                var doctor = await _context.Doctors
                    .Include(d => d.Department)
                    .Include(d => d.Specialization)
                    .FirstOrDefaultAsync(m => m.Id == id);
                if (doctor == null)
                {
                    return NotFound();
                }

                return View(doctor);
            }
			
            return RedirectToAction("Page404", "Home"); 
        }

        // GET: Doctors/Create
        public async Task<IActionResult> CreateAsync()
        {
            var checkAdmin = HttpContext.Session.GetInt32("AdminId");
            if (checkAdmin != null)
            {
                var AdminInformation = await _context.Admins.FindAsync((decimal)checkAdmin);
                ViewBag.AdminId = checkAdmin;
                ViewBag.AdminName = AdminInformation.FirstName;
                ViewBag.AdminIamge = AdminInformation.ImagePath;

                ViewData["DepartmentId"] = new SelectList(_context.Departments, "Id", "Name");
                ViewData["SpecializationId"] = new SelectList(_context.Specializations, "Id", "Name");
                return View();
            }
            return RedirectToAction("Page404", "Home");
        }

        // POST: Doctors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,Email,Phone,Address,Bod,Salary,DepartmentId,SpecializationId,ImagePath,ImageFile")] Doctor doctor, string password)
        {
            if (ModelState.IsValid)
            {
                if(doctor.ImageFile != null)
                {
                    string wwwRootPath = _webHostEnviroment.WebRootPath;
                    string fileName = Guid.NewGuid().ToString() + "_" + doctor.ImageFile.FileName;
                    //string extension = Path.GetExtension(category.ImageFile.FileName);
                    string path = Path.Combine(wwwRootPath + "/Attachments/DoctorAttachments/", fileName);
                    using (var fileStream = new FileStream(path, FileMode.Create))
                    {
                        await doctor.ImageFile.CopyToAsync(fileStream);
                    }
                    var checkEmail = _context.Users.Any(u => u.UserName == doctor.Email);
                    if (!checkEmail)
                    {
                        doctor.ImagePath = fileName;
                        doctor.AvailableDay = "Not decided yet";
                        doctor.AvailableTime = "Not decided yet";

                        _context.Add(doctor);
                        await _context.SaveChangesAsync();

                        var LastId = _context.Doctors.OrderByDescending(p => p.Id).FirstOrDefault().Id;
                        var LastEmail = _context.Doctors.OrderByDescending(p => p.Id).FirstOrDefault().Email;
                        User newuser = new User();
                        newuser.UserName = LastEmail;
                        newuser.Password = password;
                        newuser.RoleId = 2;
                        newuser.DoctorId = LastId;
                        _context.Add(newuser);
                        await _context.SaveChangesAsync();
						
						//To send Email TO Doctor
						MailMessage message = new MailMessage();
						message.To.Add(LastEmail);
						message.Subject = "Greetings From Health Care ";
						message.Body = "Welcome doctor to our clinic,\n Your email address: " +LastEmail +"\n And the password: "+password+"\n You have to log into the system and change your work days and time and password";
						message.From = new MailAddress("healthcareBAccoount@gmail.com");
						message.IsBodyHtml = false;
						SmtpClient smtp = new SmtpClient("smtp.gmail.com");
						smtp.Port = 587;
						smtp.UseDefaultCredentials = true;
						smtp.EnableSsl = true;
						smtp.Credentials = new System.Net.NetworkCredential("healthcareBAccoount@gmail.com", "Healthcare#1234");
						smtp.Send(message);

                        _notyf.Success("Doctor Add Successfuly", 3);
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        _notyf.Error("This Email already exists", 4);
                        return RedirectToAction("Create", "Doctors");
                    }
                    
                }
               
            }
            ViewData["DepartmentId"] = new SelectList(_context.Departments, "Id", "Name", doctor.DepartmentId);
            ViewData["SpecializationId"] = new SelectList(_context.Specializations, "Id", "Name", doctor.SpecializationId);
            return View(doctor);
        }

        // GET: Doctors/Edit/5
        public async Task<IActionResult> Edit(decimal? id)
        {
            var checkAdmin = HttpContext.Session.GetInt32("AdminId");
            if (checkAdmin != null)
            {
                var AdminInformation = await _context.Admins.FindAsync((decimal)checkAdmin);
                ViewBag.AdminId = checkAdmin;
                ViewBag.AdminName = AdminInformation.FirstName;
                ViewBag.AdminIamge = AdminInformation.ImagePath;
                if (id == null)
                {
                    return NotFound();
                }

                var doctor = await _context.Doctors.FindAsync(id);
                if (doctor == null)
                {
                    return NotFound();
                }
                ViewData["DepartmentId"] = new SelectList(_context.Departments, "Id", "Name", doctor.DepartmentId);
                ViewData["SpecializationId"] = new SelectList(_context.Specializations, "Id", "Name", doctor.SpecializationId);
                return View(doctor);
            }
			
            return RedirectToAction("Page404", "Home");  
        }

        // POST: Doctors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(decimal id, [Bind("Id,FirstName,LastName,Email,Phone,Address,Bod,IsAvailable,AvailableTime,AvailableDay,Salary,DepartmentId,SpecializationId,ImagePath,ImageFile")] Doctor doctor)
        {
            if (id != doctor.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if(doctor.ImageFile != null)
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
                _notyf.Success("Doctor Edit Successfuly", 3);
                return RedirectToAction(nameof(Index));
            }
            ViewData["DepartmentId"] = new SelectList(_context.Departments, "Id", "Description", doctor.DepartmentId);
            ViewData["SpecializationId"] = new SelectList(_context.Specializations, "Id", "Id", doctor.SpecializationId);
            return View(doctor);
        }

        public IActionResult Delete(int id)
        {
            Doctor model = _context.Doctors.Where(c => c.Id == id).FirstOrDefault();
            if (model != null)
            {
                _context.Doctors.Remove(model);
                _context.SaveChanges();
                _notyf.Success("Data Deleted Successfuly", 3);
            }

            return RedirectToAction(nameof(Index));
        }

        //// GET: Doctors/Delete/5
        //public async Task<IActionResult> Delete(decimal? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var doctor = await _context.Doctors
        //        .Include(d => d.Department)
        //        .Include(d => d.Specialization)
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (doctor == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(doctor);
        //}
        //// POST: Doctors/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(decimal id)
        //{
        //    var doctor = await _context.Doctors.FindAsync(id);
        //    _context.Doctors.Remove(doctor);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        private bool DoctorExists(decimal id)
        {
            return _context.Doctors.Any(e => e.Id == id);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FirstProject.Models;
using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Http;
using FirstProject.Infrastructure;

namespace FirstProject.Controllers
{
    public class AppointmentsController : Controller
    {
        private readonly ModelContext _context;
        private readonly INotyfService _notyf;

        public AppointmentsController(ModelContext context, INotyfService notyf)
        {
            _context = context;
            _notyf = notyf;
        }

        // GET: Appointments
        public async Task<IActionResult> Index()
        {
            var checkAdmin = HttpContext.Session.GetInt32("AdminId");
            if (checkAdmin != null)
            {
                var AdminInformation = await _context.Admins.FindAsync(checkAdmin);
                ViewBag.AdminId = checkAdmin;
                ViewBag.AdminName = AdminInformation.FirstName;
                ViewBag.AdminIamge = AdminInformation.ImagePath;
                var modelContext = _context.Appointments.Include(a => a.Department).Include(a => a.Doctor).Include(a => a.Patient);
                return View(await modelContext.ToListAsync());
            }
			
            return RedirectToAction("Page404", "Home");
        }

        // GET: Appointments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            var checkAdmin = HttpContext.Session.GetInt32("AdminId");
            if (checkAdmin != null)
            {
                var AdminInformation = await _context.Admins.FindAsync(checkAdmin);
                ViewBag.AdminId = checkAdmin;
                ViewBag.AdminName = AdminInformation.FirstName;
                ViewBag.AdminIamge = AdminInformation.ImagePath;
                if (id == null)
                {
                    return NotFound();
                }

                var appointment = await _context.Appointments
                    .Include(a => a.Department)
                    .Include(a => a.Doctor)
                    .Include(a => a.Patient)
                    .FirstOrDefaultAsync(m => m.Id == id);

                ViewBag.DocInfo = await _context.Doctors.Include(u => u.Specialization).FirstOrDefaultAsync(m => m.Id == appointment.DoctorId);

                if (appointment == null)
                {
                    return NotFound();
                }

                return View(appointment);
            }

            return RedirectToAction("Page404", "Home");
        }

        public IActionResult Delete(int id)
        {
            Appointment model = _context.Appointments.Where(c => c.Id == id).FirstOrDefault();
            if (model != null)
            {
                _context.Appointments.Remove(model);
                _context.SaveChanges();
                _notyf.Success("Data Deleted Successfuly", 3);
            }

            return RedirectToAction(nameof(Index));
        }
    }
}

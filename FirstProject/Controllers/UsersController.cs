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

namespace FirstProject.Controllers
{
    public class UsersController : Controller
    {
        private readonly ModelContext _context;
        private readonly INotyfService _notyf;

        public UsersController(ModelContext context, INotyfService notyf)
        {
            _context = context;
            _notyf = notyf;
        }

        // GET: Users
        public async Task<IActionResult> Index()
        {
            var checkAdmin = HttpContext.Session.GetInt32("AdminId");
            if (checkAdmin != null)
            {
                var AdminInformation = await _context.Admins.FindAsync((decimal)checkAdmin);
                ViewBag.AdminId = checkAdmin;
                ViewBag.AdminName = AdminInformation.FirstName;
                ViewBag.AdminIamge = AdminInformation.ImagePath;
                var modelContext = _context.Users.Include(u => u.Admin).Include(u => u.Doctor).Include(u => u.Patient).Include(u => u.Role);
                return View(await modelContext.ToListAsync());
            }
			
            return RedirectToAction("Page404", "Home");
        }

        // GET: Users/Details/5
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

                var user = await _context.Users
                    .Include(u => u.Admin)
                    .Include(u => u.Doctor)
                    .Include(u => u.Patient)
                    .Include(u => u.Role)
                    .FirstOrDefaultAsync(m => m.Id == id);

                
               ViewBag.DocInfo = await _context.Doctors.Include(u=>u.Department).Include(u => u.Specialization).FirstOrDefaultAsync(m => m.Id == user.DoctorId);

                if (user == null)
                {
                    return NotFound();
                }

                return View(user);
            }
			
            return RedirectToAction("Page404", "Home");  
        }


        public IActionResult Delete(int id)
        {
            User model = _context.Users.Where(c => c.Id == id).FirstOrDefault();
            if (model != null)
            {
                _context.Users.Remove(model);
                _context.SaveChanges();
                _notyf.Success("Data Deleted Successfuly", 3);
            }

            return RedirectToAction(nameof(Index));
        }


    }
}

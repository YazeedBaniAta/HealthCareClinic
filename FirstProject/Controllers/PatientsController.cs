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

namespace FirstProject.Controllers
{
    public class PatientsController : Controller
    {
        private readonly ModelContext _context;
        private readonly IWebHostEnvironment _webHostEnviroment;
        private readonly INotyfService _notyf;

        public PatientsController(ModelContext context, IWebHostEnvironment webHostEnviroment, INotyfService notyf)
        {
            _context = context;
            _webHostEnviroment = webHostEnviroment;
            _notyf = notyf;
        }

        // GET: Patients
        public async Task<IActionResult> Index()
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

        // GET: Patients/Details/5
        public async Task<IActionResult> Details(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var patient = await _context.Patients
                .FirstOrDefaultAsync(m => m.Id == id);
            if (patient == null)
            {
                return NotFound();
            }

            return View(patient);
        }

       
        public IActionResult Delete(int id)
        {
            Patient model = _context.Patients.Where(c => c.Id == id).FirstOrDefault();
            if (model != null)
            {
                _context.Patients.Remove(model);
                _context.SaveChanges();
                _notyf.Success("Data Deleted Successfuly", 3);
            }

            return RedirectToAction(nameof(Index));
        }

    }
}

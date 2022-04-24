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
    public class TestimonialSectionsController : Controller
    {
        private readonly ModelContext _context;
        private readonly INotyfService _notyf;

        public TestimonialSectionsController(ModelContext context, INotyfService notyf)
        {
            _context = context;
            _notyf = notyf;
        }

        // GET: TestimonialSections
        public async Task<IActionResult> Index()
        {
            var checkAdmin = HttpContext.Session.GetInt32("AdminId");
            if (checkAdmin != null)
            {
                var AdminInformation = await _context.Admins.FindAsync((decimal)checkAdmin);
                ViewBag.AdminId = checkAdmin;
                ViewBag.AdminName = AdminInformation.FirstName;
                ViewBag.AdminIamge = AdminInformation.ImagePath;
                var modelContext = _context.TestimonialSections.Include(t => t.Patient);
                return View(await modelContext.ToListAsync());
            }
			
            return RedirectToAction("Page404", "Home");
        }

        // GET: TestimonialSections/Details/5
        public async Task<IActionResult> Details(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var testimonialSection = await _context.TestimonialSections
                .Include(t => t.Patient)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (testimonialSection == null)
            {
                return NotFound();
            }

            return View(testimonialSection);
        }

        // GET: TestimonialSections/Edit/5
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

                var testimonialSection = await _context.TestimonialSections.FindAsync(id);
                if (testimonialSection == null)
                {
                    return NotFound();
                }
                ViewData["PatientId"] = new SelectList(_context.Patients, "Id", "FirstName", testimonialSection.PatientId);
                return View(testimonialSection);
            }
			
            return RedirectToAction("Page404", "Home"); 
        }

        // POST: TestimonialSections/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(decimal id, [Bind("Id,Subject,Description,PatientId,Status")] TestimonialSection testimonialSection)
        {
            if (id != testimonialSection.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(testimonialSection);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TestimonialSectionExists(testimonialSection.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                _notyf.Success("Data Edit Successfuly", 3);
                return RedirectToAction(nameof(Index));
            }
            ViewData["PatientId"] = new SelectList(_context.Patients, "Id", "FirstName", testimonialSection.PatientId);
            return View(testimonialSection);
        }

        public IActionResult Delete(int id)
        {
            TestimonialSection model = _context.TestimonialSections.Where(c => c.Id == id).FirstOrDefault();

            if (model != null)
            {
                _context.TestimonialSections.Remove(model);
                _context.SaveChanges();
                _notyf.Success("Data Deleted Successfuly", 3);
            }

            return RedirectToAction(nameof(Index));
        }

       
        private bool TestimonialSectionExists(decimal id)
        {
            return _context.TestimonialSections.Any(e => e.Id == id);
        }
    }
}

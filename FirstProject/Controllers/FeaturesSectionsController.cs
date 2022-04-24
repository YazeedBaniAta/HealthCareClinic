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
    public class FeaturesSectionsController : Controller
    {
        private readonly ModelContext _context;
        private readonly INotyfService _notyf;

        public FeaturesSectionsController(ModelContext context, INotyfService notyf)
        {
            _context = context;
            _notyf = notyf;
        }

        // GET: FeaturesSections
        public async Task<IActionResult> Index()
        {
            var checkAdmin = HttpContext.Session.GetInt32("AdminId");
            if (checkAdmin != null)
            {
                var AdminInformation = await _context.Admins.FindAsync((decimal)checkAdmin);
                ViewBag.AdminId = checkAdmin;
                ViewBag.AdminName = AdminInformation.FirstName;
                ViewBag.AdminIamge = AdminInformation.ImagePath;
                return View(await _context.FeaturesSections.ToListAsync());
            }
			
            return RedirectToAction("Page404", "Home");
        }

        // GET: FeaturesSections/Details/5
        public async Task<IActionResult> Details(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var featuresSection = await _context.FeaturesSections
                .FirstOrDefaultAsync(m => m.Id == id);
            if (featuresSection == null)
            {
                return NotFound();
            }

            return View(featuresSection);
        }

        
        // GET: FeaturesSections/Edit/5
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

                var featuresSection = await _context.FeaturesSections.FindAsync(id);
                if (featuresSection == null)
                {
                    return NotFound();
                }
                return View(featuresSection);
            }
			
            return RedirectToAction("Page404", "Home");
        }

        // POST: FeaturesSections/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(decimal id, [Bind("Id,TimesunWed,TimethuFri,TimesatSun,EmaegencyCase")] FeaturesSection featuresSection)
        {
            if (id != featuresSection.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(featuresSection);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FeaturesSectionExists(featuresSection.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                _notyf.Success("Edit Successfuly", 3);
                return RedirectToAction(nameof(Index));
            }
            return View(featuresSection);
        }

        private bool FeaturesSectionExists(decimal id)
        {
            return _context.FeaturesSections.Any(e => e.Id == id);
        }
    }
}

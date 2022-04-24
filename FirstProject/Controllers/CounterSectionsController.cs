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
    public class CounterSectionsController : Controller
    {
        private readonly ModelContext _context;
        private readonly INotyfService _notyf;

        public CounterSectionsController(ModelContext context, INotyfService notyf)
        {
            _context = context;
            _notyf = notyf;
        }

        // GET: CounterSections
        public async Task<IActionResult> Index()
        {
            var checkAdmin = HttpContext.Session.GetInt32("AdminId");
            if (checkAdmin != null)
            {
                var AdminInformation = await _context.Admins.FindAsync((decimal)checkAdmin);
                ViewBag.AdminId = checkAdmin;
                ViewBag.AdminName = AdminInformation.FirstName;
                ViewBag.AdminIamge = AdminInformation.ImagePath;
                return View(await _context.CounterSections.ToListAsync());
            }
			
            return RedirectToAction("Page404", "Home");
        }

        // GET: CounterSections/Details/5
        public async Task<IActionResult> Details(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var counterSection = await _context.CounterSections
                .FirstOrDefaultAsync(m => m.Id == id);
            if (counterSection == null)
            {
                return NotFound();
            }

            return View(counterSection);
        }

        
        // GET: CounterSections/Edit/5
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

                var counterSection = await _context.CounterSections.FindAsync(id);
                if (counterSection == null)
                {
                    return NotFound();
                }
                return View(counterSection);
            }
			
            return RedirectToAction("Page404", "Home");   
        }

        // POST: CounterSections/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(decimal id, [Bind("Id,HappyPeopel,SurgeryComeplet,ExpertDoctor,WordwideBranch")] CounterSection counterSection)
        {
            if (id != counterSection.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(counterSection);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CounterSectionExists(counterSection.Id))
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
            return View(counterSection);
        }

        private bool CounterSectionExists(decimal id)
        {
            return _context.CounterSections.Any(e => e.Id == id);
        }
    }
}

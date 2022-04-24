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
    public class PartnersSectionsController : Controller
    {
        private readonly ModelContext _context;
        private readonly IWebHostEnvironment _webHostEnviroment;
        private readonly INotyfService _notyf;

        public PartnersSectionsController(ModelContext context, IWebHostEnvironment webHostEnviroment, INotyfService notyf)
        {
            _context = context;
            _webHostEnviroment = webHostEnviroment;
            _notyf = notyf;
        }

        // GET: PartnersSections
        public async Task<IActionResult> Index()
        {
            var checkAdmin = HttpContext.Session.GetInt32("AdminId");
            if (checkAdmin != null)
            {
                var AdminInformation = await _context.Admins.FindAsync((decimal)checkAdmin);
                ViewBag.AdminId = checkAdmin;
                ViewBag.AdminName = AdminInformation.FirstName;
                ViewBag.AdminIamge = AdminInformation.ImagePath;
                return View(await _context.PartnersSections.ToListAsync());
            }
			
            return RedirectToAction("Page404", "Home");          
        }

        // GET: PartnersSections/Details/5
        public async Task<IActionResult> Details(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var partnersSection = await _context.PartnersSections
                .FirstOrDefaultAsync(m => m.Id == id);
            if (partnersSection == null)
            {
                return NotFound();
            }

            return View(partnersSection);
        }

        // GET: PartnersSections/Create
        public async Task<IActionResult> CreateAsync()
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

        // POST: PartnersSections/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Description,ImagePath,ImageFile")] PartnersSection partnersSection)
        {
            if (ModelState.IsValid)
            {
                if (partnersSection.ImageFile != null)
                {
                    string wwwRootPath = _webHostEnviroment.WebRootPath;
                    string fileName = Guid.NewGuid().ToString() + "_" + partnersSection.ImageFile.FileName;
                    //string extension = Path.GetExtension(category.ImageFile.FileName);
                    string path = Path.Combine(wwwRootPath + "/Attachments/PartnersSectionAttachment/", fileName);
                    using (var fileStream = new FileStream(path, FileMode.Create))
                    {
                        await partnersSection.ImageFile.CopyToAsync(fileStream);
                    }
                    partnersSection.ImagePath = fileName;
                }
                _context.Add(partnersSection);
                await _context.SaveChangesAsync();
                _notyf.Success("Add Successfuly", 3);
                return RedirectToAction(nameof(Index));
            }
            return View(partnersSection);
        }

        // GET: PartnersSections/Edit/5
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

                var partnersSection = await _context.PartnersSections.FindAsync(id);
                if (partnersSection == null)
                {
                    return NotFound();
                }
                return View(partnersSection);
            }
			
            return RedirectToAction("Page404", "Home");  
        }

        // POST: PartnersSections/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(decimal id, [Bind("Id,Description,ImagePath,ImageFile")] PartnersSection partnersSection)
        {
            if (id != partnersSection.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (partnersSection.ImageFile != null)
                    {
                        string wwwRootPath = _webHostEnviroment.WebRootPath;
                        string fileName = Guid.NewGuid().ToString() + "_" + partnersSection.ImageFile.FileName;
                        //string extension = Path.GetExtension(category.ImageFile.FileName);
                        string path = Path.Combine(wwwRootPath + "/Attachments/PartnersSectionAttachment/", fileName);
                        using (var fileStream = new FileStream(path, FileMode.Create))
                        {
                            await partnersSection.ImageFile.CopyToAsync(fileStream);
                        }
                        partnersSection.ImagePath = fileName;
                    }
                    _context.Update(partnersSection);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PartnersSectionExists(partnersSection.Id))
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
            return View(partnersSection);
        }

        public IActionResult Delete(int id)
        {
            PartnersSection model = _context.PartnersSections.Where(c => c.Id == id).FirstOrDefault();
            if (model != null)
            {
                _context.PartnersSections.Remove(model);
                _context.SaveChanges();
                _notyf.Success("Data Deleted Successfuly", 3);
            }

            return RedirectToAction(nameof(Index));
        }

        private bool PartnersSectionExists(decimal id)
        {
            return _context.PartnersSections.Any(e => e.Id == id);
        }
    }
}

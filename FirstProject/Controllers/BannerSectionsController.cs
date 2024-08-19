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
using FirstProject.Infrastructure;

namespace FirstProject.Controllers
{
    public class BannerSectionsController : Controller
    {
        private readonly ModelContext _context;
        private readonly IWebHostEnvironment _webHostEnviroment;
        private readonly INotyfService _notyf;

        public BannerSectionsController(ModelContext context, IWebHostEnvironment webHostEnviroment, INotyfService notyf)
        {
            _context = context;
            _webHostEnviroment = webHostEnviroment;
            _notyf = notyf;
        }

        // GET: BannerSections
        public async Task<IActionResult> Index()
        {
            var checkAdmin = HttpContext.Session.GetInt32("AdminId");
            if (checkAdmin != null)
            {
                var AdminInformation = await _context.Admins.FindAsync(checkAdmin);
                ViewBag.AdminId = checkAdmin;
                ViewBag.AdminName = AdminInformation.FirstName;
                ViewBag.AdminIamge = AdminInformation.ImagePath;
                return View(await _context.BannerSections.ToListAsync());
            }
			
            return RedirectToAction("Page404", "Home");
        }

       
       // GET: BannerSections/Edit/5
        public async Task<IActionResult> Edit(int? id)
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

                var bannerSection = await _context.BannerSections.FindAsync(id);
                if (bannerSection == null)
                {
                    return NotFound();
                }
                return View(bannerSection);
            }
			
            return RedirectToAction("Page404", "Home");
            
        }

        // POST: BannerSections/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Description,ImagePath,ImageFile")] BannerSection bannerSection)
        {
            if (id != bannerSection.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (bannerSection.ImageFile != null)
                    {
                        string wwwRootPath = _webHostEnviroment.WebRootPath;
                        string fileName = Guid.NewGuid().ToString() + "_" + bannerSection.ImageFile.FileName;
                        //string extension = Path.GetExtension(category.ImageFile.FileName);
                        string path = Path.Combine(wwwRootPath + "/Attachments/BannerSectionAttachment/", fileName);
                        using (var fileStream = new FileStream(path, FileMode.Create))
                        {
                            await bannerSection.ImageFile.CopyToAsync(fileStream);
                        }
                        bannerSection.ImagePath = fileName;
                    }
                    _context.Update(bannerSection);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BannerSectionExists(bannerSection.Id))
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
            return View(bannerSection);
        }

        private bool BannerSectionExists(int id)
        {
            return _context.BannerSections.Any(e => e.Id == id);
        }
    }
}

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
    public class HeadSectionsController : Controller
    {
        private readonly ModelContext _context;
        private readonly IWebHostEnvironment _webHostEnviroment;
        private readonly INotyfService _notyf;

        public HeadSectionsController(ModelContext context, IWebHostEnvironment webHostEnviroment, INotyfService notyf)
        {
            _context = context;
            _webHostEnviroment = webHostEnviroment;
            _notyf = notyf;
        }

        // GET: HeadSections
        public async Task<IActionResult> Index()
        {
            var checkAdmin = HttpContext.Session.GetInt32("AdminId");
            if (checkAdmin != null)
            {
                var AdminInformation = await _context.Admins.FindAsync(checkAdmin);
                ViewBag.AdminId = checkAdmin;
                ViewBag.AdminName = AdminInformation.FirstName;
                ViewBag.AdminIamge = AdminInformation.ImagePath;
                return View(await _context.HeadSections.ToListAsync());
            }
			
            return RedirectToAction("Page404", "Home");
        }

        // GET: HeadSections/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var headSection = await _context.HeadSections
                .FirstOrDefaultAsync(m => m.Id == id);
            if (headSection == null)
            {
                return NotFound();
            }

            return View(headSection);
        }

      
        // GET: HeadSections/Edit/5
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

                var headSection = await _context.HeadSections.FindAsync(id);
                if (headSection == null)
                {
                    return NotFound();
                }
                return View(headSection);
            }
			
            return RedirectToAction("Page404", "Home");  
        }

        // POST: HeadSections/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ClinicName,ClinicAddress,ClinicEmail,ImagePath,ImageFile")] HeadSection headSection)
        {
            if (id != headSection.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (headSection.ImageFile != null)
                    {
                        string wwwRootPath = _webHostEnviroment.WebRootPath;
                        string fileName = Guid.NewGuid().ToString() + "_" + headSection.ImageFile.FileName;
                        //string extension = Path.GetExtension(category.ImageFile.FileName);
                        string path = Path.Combine(wwwRootPath + "/Attachments/HeadSectionAttachment/", fileName);
                        using (var fileStream = new FileStream(path, FileMode.Create))
                        {
                            await headSection.ImageFile.CopyToAsync(fileStream);
                        }
                        headSection.ImagePath = fileName;
                    }
                    _context.Update(headSection);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HeadSectionExists(headSection.Id))
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
            return View(headSection);
        }
        
        private bool HeadSectionExists(int id)
        {
            return _context.HeadSections.Any(e => e.Id == id);
        }
    }
}

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
    public class ServicePagesController : Controller
    {
        private readonly ModelContext _context;
        private readonly IWebHostEnvironment _webHostEnviroment;
        private readonly INotyfService _notyf;

        public ServicePagesController(ModelContext context, IWebHostEnvironment webHostEnviroment, INotyfService notyf)
        {
            _context = context;
            _webHostEnviroment = webHostEnviroment;
            _notyf = notyf;
        }

        // GET: ServicePages
        public async Task<IActionResult> Index()
        {
            var checkAdmin = HttpContext.Session.GetInt32("AdminId");
            if (checkAdmin != null)
            {
                var AdminInformation = await _context.Admins.FindAsync(checkAdmin);
                ViewBag.AdminId = checkAdmin;
                ViewBag.AdminName = AdminInformation.FirstName;
                ViewBag.AdminIamge = AdminInformation.ImagePath;
                return View(await _context.ServicePages.ToListAsync());
            }
			
            return RedirectToAction("Page404", "Home"); 
        }

        // GET: ServicePages/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var servicePage = await _context.ServicePages
                .FirstOrDefaultAsync(m => m.Id == id);
            if (servicePage == null)
            {
                return NotFound();
            }

            return View(servicePage);
        }

        // GET: ServicePages/Create
        public async Task<IActionResult> CreateAsync()
        {
            var checkAdmin = HttpContext.Session.GetInt32("AdminId");
            if (checkAdmin != null)
            {
                var AdminInformation = await _context.Admins.FindAsync(checkAdmin);
                ViewBag.AdminId = checkAdmin;
                ViewBag.AdminName = AdminInformation.FirstName;
                ViewBag.AdminIamge = AdminInformation.ImagePath;
                return View();
            }
			
            return RedirectToAction("Page404", "Home");
        }

        // POST: ServicePages/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Description,ImagePath,ImageFile")] ServicePage servicePage)
        {
            if (ModelState.IsValid)
            {
                if (servicePage.ImageFile != null)
                {
                    string wwwRootPath = _webHostEnviroment.WebRootPath;
                    string fileName = Guid.NewGuid().ToString() + "_" + servicePage.ImageFile.FileName;
                    //string extension = Path.GetExtension(category.ImageFile.FileName);
                    string path = Path.Combine(wwwRootPath + "/Attachments/ServiceAttachments/", fileName);
                    using (var fileStream = new FileStream(path, FileMode.Create))
                    {
                        await servicePage.ImageFile.CopyToAsync(fileStream);
                    }
                    servicePage.ImagePath = fileName;
                }
                _context.Add(servicePage);
                await _context.SaveChangesAsync();
                _notyf.Success("Service Add Successfuly", 3);
                return RedirectToAction(nameof(Index));
            }
            return View(servicePage);
        }

        // GET: ServicePages/Edit/5
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

                var servicePage = await _context.ServicePages.FindAsync(id);
                if (servicePage == null)
                {
                    return NotFound();
                }
                return View(servicePage);
            }
			
            return RedirectToAction("Page404", "Home"); 
        }

        // POST: ServicePages/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Description,ImagePath,ImageFile")] ServicePage servicePage)
        {
            if (id != servicePage.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (servicePage.ImageFile != null)
                    {
                        string wwwRootPath = _webHostEnviroment.WebRootPath;
                        string fileName = Guid.NewGuid().ToString() + "_" + servicePage.ImageFile.FileName;
                        //string extension = Path.GetExtension(category.ImageFile.FileName);
                        string path = Path.Combine(wwwRootPath + "/Attachments/ServiceAttachments/", fileName);
                        using (var fileStream = new FileStream(path, FileMode.Create))
                        {
                            await servicePage.ImageFile.CopyToAsync(fileStream);
                        }
                        servicePage.ImagePath = fileName;
                    }
                    _context.Update(servicePage);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ServicePageExists(servicePage.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                _notyf.Success("Service Edit Successfuly", 3);
                return RedirectToAction(nameof(Index));
            }
            return View(servicePage);
        }

        public IActionResult Delete(int id)
        {
            ServicePage model = _context.ServicePages.Where(c => c.Id == id).FirstOrDefault();
            if (model != null)
            {
                _context.ServicePages.Remove(model);
                _context.SaveChanges();
                _notyf.Success("Data Deleted Successfuly", 3);
            }

            return RedirectToAction(nameof(Index));
        }

        private bool ServicePageExists(int id)
        {
            return _context.ServicePages.Any(e => e.Id == id);
        }
    }
}

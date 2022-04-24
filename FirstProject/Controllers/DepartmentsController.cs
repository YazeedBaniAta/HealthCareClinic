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
    public class DepartmentsController : Controller
    {
        private readonly ModelContext _context;
        private readonly IWebHostEnvironment _webHostEnviroment;
        private readonly INotyfService _notyf;

        public DepartmentsController(ModelContext context, IWebHostEnvironment webHostEnviroment, INotyfService notyf)
        {
            _context = context;
            _webHostEnviroment = webHostEnviroment;
            _notyf = notyf;
        }

        // GET: Departments
        public async Task<IActionResult> Index()
        {
            var checkAdmin = HttpContext.Session.GetInt32("AdminId");
            if (checkAdmin != null)
            {
                var AdminInformation = await _context.Admins.FindAsync((decimal)checkAdmin);
                ViewBag.AdminId = checkAdmin;
                ViewBag.AdminName = AdminInformation.FirstName;
                ViewBag.AdminIamge = AdminInformation.ImagePath;
                return View(await _context.Departments.ToListAsync());
            }
			
            return RedirectToAction("Page404", "Home");
 
        }

        // GET: Departments/Details/5
        public async Task<IActionResult> Details(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var department = await _context.Departments
                .FirstOrDefaultAsync(m => m.Id == id);
            if (department == null)
            {
                return NotFound();
            }

            return View(department);
        }

        // GET: Departments/Create
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

        // POST: Departments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,ImagePath,ImageFile")] Department department)
        {
            if (ModelState.IsValid)
            {
                if (department.ImageFile != null)
                {
                    string wwwRootPath = _webHostEnviroment.WebRootPath;
                    string fileName = Guid.NewGuid().ToString() + "_" + department.ImageFile.FileName;
                    //string extension = Path.GetExtension(category.ImageFile.FileName);
                    string path = Path.Combine(wwwRootPath + "/Attachments/DepartmentAttachments/", fileName);
                    using (var fileStream = new FileStream(path, FileMode.Create))
                    {
                        await department.ImageFile.CopyToAsync(fileStream);
                    }
                    department.ImagePath = fileName;

                    _context.Add(department);
                    await _context.SaveChangesAsync();
                    _notyf.Success("Clinic Add Successfuly", 3);
                    return RedirectToAction(nameof(Index));
                }

                
            }
            return View(department);
        }

        // GET: Departments/Edit/5
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

                var department = await _context.Departments.FindAsync(id);
                if (department == null)
                {
                    return NotFound();
                }
                return View(department);
            }
			
            return RedirectToAction("Page404", "Home");

           
        }

        // POST: Departments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(decimal id, [Bind("Id,Name,Description,ImagePath,ImageFile")] Department department)
        {
            if (id != department.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (department.ImageFile != null)
                    {
                        string wwwRootPath = _webHostEnviroment.WebRootPath;
                        string fileName = Guid.NewGuid().ToString() + "_" + department.ImageFile.FileName;
                        //string extension = Path.GetExtension(category.ImageFile.FileName);
                        string path = Path.Combine(wwwRootPath + "/Attachments/DepartmentAttachments/", fileName);
                        using (var fileStream = new FileStream(path, FileMode.Create))
                        {
                            await department.ImageFile.CopyToAsync(fileStream);
                        }
                        department.ImagePath = fileName;
                    }
                    _context.Update(department);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DepartmentExists(department.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                _notyf.Success("Clinic Edit Successfuly", 3);
                return RedirectToAction(nameof(Index));
            }
            return View(department);
        }

        public IActionResult Delete(int id)
        {
            Department model = _context.Departments.Where(c => c.Id == id).FirstOrDefault();
            
            if(model != null)
            {
                _context.Departments.Remove(model);
                _context.SaveChanges();
                _notyf.Success("Data Deleted Successfuly", 3);
            }
            return RedirectToAction(nameof(Index));
        }

        private bool DepartmentExists(decimal id)
        {
            return _context.Departments.Any(e => e.Id == id);
        }
    }
}

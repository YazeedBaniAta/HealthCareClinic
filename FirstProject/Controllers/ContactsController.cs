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
using FirstProject.Infrastructure;

namespace FirstProject.Controllers
{
    public class ContactsController : Controller
    {
        private readonly ModelContext _context;
        private readonly INotyfService _notyf;

        public ContactsController(ModelContext context, INotyfService notyf)
        {
            _context = context;
            _notyf = notyf;
        }

        // GET: Contacts
        public async Task<IActionResult> Index()
        {
            var checkAdmin = HttpContext.Session.GetInt32("AdminId");
            if (checkAdmin != null)
            {
                var AdminInformation = await _context.Admins.FindAsync(checkAdmin);
                ViewBag.AdminId = checkAdmin;
                ViewBag.AdminName = AdminInformation.FirstName;
                ViewBag.AdminIamge = AdminInformation.ImagePath;
                return View(await _context.Contacts.ToListAsync());
            }
			
            return RedirectToAction("Page404", "Home"); 
        }

        // GET: Contacts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contact = await _context.Contacts
                .FirstOrDefaultAsync(m => m.Id == id);
            if (contact == null)
            {
                return NotFound();
            }

            return View(contact);
        }

     
        public IActionResult Delete(int id)
        {
            Contact model = _context.Contacts.Where(c => c.Id == id).FirstOrDefault();

            if (model != null)
            {
                _context.Contacts.Remove(model);
                _context.SaveChanges();
                _notyf.Success("Data Deleted Successfuly", 3);
            }
            return RedirectToAction(nameof(Index));
        }

       
        private bool ContactExists(int id)
        {
            return _context.Contacts.Any(e => e.Id == id);
        }
    }
}

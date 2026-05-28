using Assignment_1.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Assignment_1.Models;

namespace Assignment_1.Controllers
{
    public class ContactController : Controller
    {
        IContactRepository _contactRepository;

        public ContactController()
        {
            _contactRepository = new ConcreteContact();
        }
        // GET: Contact
        public async Task<ActionResult> Index()
        {
            var contact = await _contactRepository.GetAllAsync();
            return View(contact);
        }

        //GET: Contact/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Contact contact)
        {
            if (ModelState.IsValid)
            {
                await _contactRepository.CreateAsync(contact);
                return RedirectToAction("Index");
            }
            return View(contact);
        }

        // GET: Contact/Delete/5
        public async Task<ActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            var contact = await _contactRepository.GetAllAsync();
            var getcontact = (from c in contact
                              where c.Id == id
                              select c).FirstOrDefault();
            if (getcontact == null)
            {
                return HttpNotFound();
            }
            return View(getcontact);
        }


        // POST: Contact/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(long id)
        {
            await _contactRepository.DeleteAsync(id);
            return RedirectToAction("Index");
        }
    }
}
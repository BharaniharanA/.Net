using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Assignment_1.Models;
using Microsoft.Ajax.Utilities;

namespace Assignment_1.Repository
{
    public class ConcreteContact : IContactRepository
    {
        ContactContext db;
        DbSet<Contact> dbset;
        public ConcreteContact()
        {
            db = new ContactContext();
            dbset = db.Set<Contact>();
        }
        public async Task<List<Contact>> GetAllAsync()
        {
            return await dbset.ToListAsync();
        }

        public async Task CreateAsync(Contact contact)
        {
           dbset.Add(contact);
           await db.SaveChangesAsync();
        }

        public async Task DeleteAsync(long id)
        {
            var getmodel = await dbset.FindAsync(id);
            dbset.Remove(getmodel);
            await db.SaveChangesAsync();
        }
    }
}
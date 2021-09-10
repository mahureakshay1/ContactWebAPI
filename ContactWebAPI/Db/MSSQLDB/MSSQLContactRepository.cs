using ContactWebAPI.Db.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactWebAPI.Db.MSSQLDB
{
    public class MSSQLContactRepository : IContactRepository
    {

        private readonly CMSDbContext context;
        public MSSQLContactRepository(CMSDbContext context)
        {
            this.context = context;
        }
        public Contact Add(Contact ct)
        {
            context.Contacts.Add(ct);
            context.SaveChanges();
            return ct;
        }

        public Contact Get(int id)
        {
            return context.Contacts.Find(id);
        }

        public IEnumerable<Contact> GetAll()
        {
            return context.Contacts;
        }

        public Contact SetStatus(int id, bool status)
        {
            var ct = context.Contacts.Find(id);
            if (ct != null)
            {
                ct.ContactStatus = status;
                var change= context.Contacts.Attach(ct);
                change.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                context.SaveChanges();
            }
            return ct;
        }

        public Contact Update(Contact ct)
        {
            var contact = context.Contacts.Attach(ct);
            contact.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return ct;
        }



    }
}

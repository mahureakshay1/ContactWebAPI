using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactWebAPI.Db.Repository
{
    public interface IContactRepository
    {
        public Contact Add(Contact ct);

        public Contact Update(Contact ct);

        public Contact Get(int id);

        public IEnumerable<Contact> GetAll();

        public Contact SetStatus(int id, bool status);
        

    }
}

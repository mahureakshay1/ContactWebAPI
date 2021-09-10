using ContactWebAPI;
using ContactWebAPI.Db.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CMSWebAPITest
{
    class ContactFakeRepository : IContactRepository
    {

        List<Contact> contactList = new List<Contact>()
        {
             new Contact() { ContactId=1, FirstName ="Akshay", LastName="Mahure",ContactAddress="Madheli tah Warora, dist Chandrapur", ContactStatus=true, Email="mahureakshay1@gmail.com", PhoneNumber="8888589205"        },
             new Contact() { ContactId=2, FirstName ="Mayur", LastName="Pimpalkar",ContactAddress="Babupeth tah warora, dist Chandrapur", ContactStatus=true, Email="mahureakshay2@gmail.com", PhoneNumber="8888589206"        },
             new Contact() { ContactId=3, FirstName ="Viaks", LastName="Gondane",ContactAddress="Bramhapuri tah Bramhapuri, dist Chandrapur", ContactStatus=true, Email="mahureakshay3@gmail.com", PhoneNumber="8888589207"        },
             new Contact() { ContactId=4, FirstName ="Magesh", LastName="Tembhurne",ContactAddress="Talodhi tah Bramhapuri, dist Chandrapur", ContactStatus=true, Email="mahureakshay4@gmail.com", PhoneNumber="8888589208"        }
        };

        public Contact Add(Contact ct)
        {
            var count = contactList.Count();
            ct.ContactId = count + 1;
            contactList.Add(ct);
            return ct;
        }

        public Contact Get(int id)
        {
            return contactList.Find(x => x.ContactId == id);
        }

        public IEnumerable<Contact> GetAll()
        {
            return contactList;
        }

        public Contact SetStatus(int id, bool status)
        {
            var contact = contactList.Find(x => x.ContactId == id);
            contact.ContactStatus = status;
            return contact;
        }

        public Contact Update(Contact ct)
        {
            var contact = contactList.Find(x => x.ContactId == ct.ContactId);
            contact = ct;
            return contact;
        }
    }
}

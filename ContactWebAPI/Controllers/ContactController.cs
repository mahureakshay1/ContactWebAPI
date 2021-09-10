using ContactWebAPI.Db.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using ContactWebAPI.Authentication;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Cors;

namespace ContactWebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [BasicAuthorization]
    public class ContactController : ControllerBase
    {
        private readonly IContactRepository _contactRepository;

        public ContactController(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        [HttpGet]
        public IEnumerable<Contact> Get()
        {
            return _contactRepository.GetAll();
        }

        [HttpGet("{id}")]
        public Contact Get(int id)
        {
            return _contactRepository.Get(id);
        }

        [HttpPost]
        public Contact Add([FromBody] Contact ct)
        {
            return _contactRepository.Add(ct);

        }

        [HttpPut]
        public Contact Update([FromBody] Contact ct)
        {

            return _contactRepository.Update(ct);

        }

        [HttpPost("SetStatus/{id}/{status}")]
        public Contact SetStatus(int id, bool status)
        {
            return _contactRepository.SetStatus(id, status);
        }


    }
}

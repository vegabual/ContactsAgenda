using API_Contacts.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Contacts.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContactController : ControllerBase
    {
        private ContactService contactService = new ContactService();

        [HttpGet]
        public Contact Get(int id)
        {
            return contactService.Get(id);
        }

        [HttpGet]
        public IEnumerable<Contact> Get()
        {
            return contactService.Get();
        }

        [HttpPost]
        public ActionResult Save(Contact contact)
        {
            return CreatedAtAction(nameof(Save), contactService.Save(contact));
        }

        [HttpPut]
        public IActionResult Edit(int id, Contact contact)
        {
            contactService.Edit(id, contact);
            return NoContent();
        }

        [HttpDelete]
        public IActionResult Delete (int id)
        {
            contactService.Delete(id);
            return NoContent();
        }
    }
}

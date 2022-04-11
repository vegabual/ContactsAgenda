using API_Contacts.DTO;
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

        [HttpGet("{id}")]
        public ContactDTO Get(int id)
        {
            return contactService.GetDTO(id);
        }

        [HttpGet]
        public IEnumerable<ContactDTO> Get()
        {
            return contactService.GetDTO();
        }

        [HttpPost]
        public ActionResult Save(ContactDTO contact)
        {
            return CreatedAtAction(nameof(Save), contactService.Save(contact));
        }

        [HttpPut]
        public IActionResult Edit(int id, ContactDTO contact)
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

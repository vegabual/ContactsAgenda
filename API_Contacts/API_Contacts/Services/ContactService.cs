using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API_Contacts.DTO;

namespace API_Contacts.Services
{
    public class ContactService
    {
        private string saveFileFolder = "../SaveFiles";
        private string saveFileName = "Contacts.json";

        public ContactDTO GetDTO(int id)
        {
            return this.Get().FirstOrDefault(x => x.Id == id).ToDTO();
        }

        private IEnumerable<Contact> Get()
        {
            return JsonSaverService.GetJson<List<Contact>>(saveFileFolder, saveFileName);
        }

        public IEnumerable<ContactDTO> GetDTO()
        {
            return this.Get().Select(x => x.ToDTO());
        }

        public int Save(ContactDTO contact)
        {
            var contacts = this.Get().ToList();
            var maxId = contacts.Count == 0 ? 0 : contacts.Max(x => x.Id);
            var newContact = new Contact
            {
                Id = maxId + 1,
                FirstName = contact.FirstName,
                SecondName = contact.SecondName,
                FirstSurname = contact.FirstSurname,
                SecondSurname = contact.SecondSurname,
                CellphoneNumber = contact.CellphoneNumber,
                PhoneNumber = contact.PhoneNumber
            };
            contacts.Add(newContact);
            JsonSaverService.SaveJson(saveFileFolder, saveFileName, contacts);
            return newContact.Id;
        }

        public void Edit(int id, ContactDTO contact)
        {
            List<Contact> contacts = this.Get().ToList();
            Contact original = contacts.FirstOrDefault(x => x.Id == id);
            if(original == null)
            {
                throw new KeyNotFoundException();
            }
            original.FirstName = contact.FirstName != null ? contact.FirstName : original.FirstName;
            original.SecondName = contact.SecondName != null ? contact.SecondName : original.SecondName;
            original.FirstSurname = contact.FirstSurname != null ? contact.FirstSurname : original.FirstSurname;
            original.SecondSurname = contact.SecondSurname != null ? contact.SecondSurname : original.SecondSurname;
            original.CellphoneNumber = contact.CellphoneNumber != null ? contact.CellphoneNumber : original.CellphoneNumber;
            original.PhoneNumber = contact.PhoneNumber != null ? contact.PhoneNumber : original.PhoneNumber;
            JsonSaverService.SaveJson(saveFileFolder, saveFileName, contacts);
        }

        public void Delete(int id)
        {
            List<Contact> contacts = this.Get().ToList();
            contacts.Remove(contacts.FirstOrDefault(x => x.Id == id));
            JsonSaverService.SaveJson(saveFileFolder, saveFileName, contacts);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Contacts.Services
{
    public class ContactService
    {
        private string saveFilePath = "/Saves/preferences.xml";

        public Contact Get(int id)
        {
            return this.Get().FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Contact> Get()
        {
            return JsonSaverServicecs.GetJson<List<Contact>>(saveFilePath);
        }

        public void Save(Contact contact)
        {
            List<Contact> contacts = this.Get().OrderBy(x => x.Id).ToList();
            int id = contacts.Count > 0 ? contacts.Last().Id + 1 : 0;
            contact.Id = id;
            contacts.Add(contact);
            JsonSaverServicecs.SaveJson(saveFilePath, contacts);
        }

        public void Edit(int id, Contact contact)
        {
            List<Contact> contacts = this.Get().ToList();
            Contact original = contacts.FirstOrDefault(x => x.Id == id);
            if(original == null)
            {
                throw new KeyNotFoundException();
            }
            contacts.Remove(contacts.FirstOrDefault(x => x.Id == id));
            contacts.Add(contact);
            JsonSaverServicecs.SaveJson(saveFilePath, contacts);
        }

        public void Delete(int id)
        {
            List<Contact> contacts = this.Get().ToList();
            contacts.Remove(contacts.FirstOrDefault(x => x.Id == id));
            JsonSaverServicecs.SaveJson(saveFilePath, contacts);
        }
    }
}

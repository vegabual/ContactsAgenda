using API_Contacts.DTO;
using System;

namespace API_Contacts
{
    public class Contact
    {
        public int Id { get; set; }
        public string FirstName { get; set; }

        public string SecondName { get; set; }

        public string FirstSurname { get; set; }

        public string SecondSurname { get; set; }

        public string CellphoneNumber { get; set; }

        public string PhoneNumber { get; set; }

        public ContactDTO ToDTO()
        {
            return new ContactDTO
            {
                FirstName = this.FirstName,
                SecondName = this.SecondName,
                FirstSurname = this.FirstSurname,
                SecondSurname = this.SecondSurname,
                CellphoneNumber = this.CellphoneNumber,
                PhoneNumber = this.PhoneNumber
            };
        }
    }
}

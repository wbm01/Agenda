using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agenda
{
    internal class Contact
    {
        public string Name { get; set; }
        public Address Address { get; set; }
        public string Phone { get; set; }
        public string? Email { get; set; }

        public Contact(string name, string phone, string email){ 
        
            this.Name = name;
            this.Phone = phone;
            this.Email = email;
            this.Address = new Address();
        }

        public string EditPhone(string phone)
        {
            this.Phone = phone;
            return this.Phone;
        }

        public string EditEmail(string email) { 
            this.Email = email;
            return this.Email;
        }

        public string EditName(string name)
        {
            this.Name = name;
            return this.Name;
        }

        public string ToUser()
        {

            return "Nome: " + Name + "\nTelefone: " + Phone + "\nEmail: " + Email + Address.ToUser();
        }

        public override string ToString()
        {
            return Name + "," + Phone + "," + Email + "," + Address.ToString();
        }
    }
}

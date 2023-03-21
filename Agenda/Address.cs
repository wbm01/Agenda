using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agenda
{
    internal class Address
    {
        public string Street;
        public string City;
        public string State;
        public string PostalCode;
        public string Country;

        public Address()
        {

        }

        public void EditStreet(string street)
        {
            this.Street = street;
        }

        public void EditCity(string city)
        {
            this.City = city;
        }

        public void EditState(string state)
        {
            this.State = state;
        }

        public void EditPostalCode(string postalcode)
        {
            this.PostalCode = postalcode;
        }

        public void EditCountry(string country)
        {
            this.Country = country;
        }
        
        public override string ToString() { 
        
        return "\nEndereço: " + Street + "\nEstado: " + State + "\nCidade: " + City +
                "\nPaís: " + Country + "\nCEP: " + PostalCode;
        }
    }
}

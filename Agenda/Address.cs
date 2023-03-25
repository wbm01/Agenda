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

        public Address(string street, string city, string state, string country, string postalcode)
        {
            this.Street = street;
            this.City = city;
            this.State = state;
            this.Country = country;
            this.PostalCode = postalcode;
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
        
        return Street + "," + City + "," + State + "," + Country + "," + PostalCode;
        }

        public string ToUser()
        {
            return "\nEndereço: " + Street + "\nEstado: " + State + "\nCidade: " + City +
               "\nPaís: " + Country + "\nCEP: " + PostalCode;
        }
    }
}

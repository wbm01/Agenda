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

        public string EditStreet(string street)
        {
            this.Street = street;
            return this.Street;
        }

        public string EditCity(string city)
        {
            this.City = city;
            return this.City;
        }

        public string EditState(string state)
        {
            this.State = state;
            return this.State;
        }

        public string EditPostalCode(string postalcode)
        {
            this.PostalCode = postalcode;
            return this.PostalCode;
        }

        public string EditCountry(string country)
        {
            this.Country = country;
            return this.Country;
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

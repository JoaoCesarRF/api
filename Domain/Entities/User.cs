using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class User : EntityBase
    {

        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public Name Name { get; set; }
        public Address Address { get; set; }
        public string Phone { get; set; }
        public string Status { get; set; } 
        public string Role { get; set; }   
    }

    public class Name
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
    }

    public class Address
    {
        public string City { get; set; }
        public string Street { get; set; }
        public int Number { get; set; }
        public string Zipcode { get; set; }
        public Geolocation Geolocation { get; set; }
    }

    public class Geolocation
    {
        public string Lat { get; set; }
        public string Long { get; set; }
    }
}

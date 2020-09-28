using System;
using System.Collections.Generic;
using System.Text;

namespace BookShopping
{
    class Person
    {
        private int id;
        private int gender;
        private string givenName;
        private string surname;
        private string streetAddress;
        private int zipCode;
        private string city;
        private string email;
        private string username;
        private string password;
        private DateTime birthday;

       
        public int Id { get => id; set => id = value; }
        public int Gender { get => gender; set => gender = value; }
        public string GivenName { get => givenName; set => givenName = value; }
        public string Surname { get => surname; set => surname = value; }
        public string StreetAddress { get => streetAddress; set => streetAddress = value; }
        public int ZipCode { get => zipCode; set => zipCode = value; }
        public string City { get => city; set => city = value; }
        public string Email { get => email; set => email = value; }
        public string Username { get => username; set => username = value; }
        public string Password { get => password; set => password = value; }
        public DateTime Birthday { get => birthday; set => birthday = value; }

        public override string ToString()
        {
            char comma = ',';
            return gender + comma + givenName + comma + surname + comma + streetAddress + comma + zipCode + comma + city + comma + email
                + comma + username + comma + password + comma + birthday.ToString("d");
        }
    }
}

using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KundRegister
{
    public class Customer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public bool IsCompany { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string StreetName { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public bool WantNewsLetter { get; set; }
        public string Notes { get; set; }

        public Customer()
        {
            
        }
        public Customer(bool isCompany, string firstName, string lastName, DateTime birthDate, string streetName, string zipCode, string city, string phoneNumber, string email, bool wantNewsLetter, string notes)
        {
            IsCompany = isCompany;
            FirstName = firstName;
            LastName = lastName;
            BirthDate = birthDate;
            StreetName = streetName;
            ZipCode = zipCode;
            City = city;
            PhoneNumber = phoneNumber;
            Email = email;
            WantNewsLetter = wantNewsLetter;
            Notes = notes;
        }
    }
}

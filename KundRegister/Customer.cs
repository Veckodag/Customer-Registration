using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KundRegister
{
    public class Customer
    {
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
        public Guid CustomerNumber { get; set; }

    }
}

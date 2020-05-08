using System;
using System.ComponentModel.DataAnnotations;


namespace TMCatalog.Model
{
    public class Client
    {
        [Key]
        public int Id { get; set; }

        public int CardNumber { get; set; }
        
        public string Cnp { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public int Gender { get; set; }

        public DateTime BirthDate { get; set; }

        public DateTime RegisteredDate { get; set; }

        public byte[] Photo { get; set; }

        public string Comment { get; set; }

        public bool Active { get; set; }
    }
}

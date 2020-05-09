using System;
using System.ComponentModel.DataAnnotations;
using System.Drawing;

namespace TMCatalog.Model
{

    public class Client
    {
        [Key]
        public int Id { get; set; }

        public int CardNumber { get; set; }

        public long Cnp { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PhoneNumber { get; set; }

        public string EmailAddress { get; set; }

        public string Gender { get; set; }

        public DateTime BirthDate { get; set; }

        public DateTime RegisteredDate { get; set; }

        //public Bitmap Photo { get; set; }

        public string Comment { get; set; }

        public bool Active { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMCatalog.Model
{
    public class Ticket
    {
        [Key]
        public int Id { get; set; }

        public string Type { get; set; }

        public short MaxEntrance { get; set; }

        public short ValidityNumber { get; set; }

        public bool Active { get; set; }

        public float Price { get; set; }

        public float Discount { get; set; }

        public DateTime DiscountFrom { get; set; }

        public DateTime DiscountUntil { get; set; }

        public string Comment{ get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMCatalog.Model
{
    public class ClientMembership
    {
        [Key]
        public int Id { get; set; }

        public int ClientId { get; set; }

        public Client Client { get; set; }

        public int TicketId { get; set; }

        public Ticket Ticket { get; set; }

        public DateTime ValidAfter { get; set; }

        public short EntranceLeft { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }

        public DateTime SoldOn { get; set; }

        public bool Active { get; set; }

        public float Price { get; set; }

        public string Comment { get; set; }
    }
}

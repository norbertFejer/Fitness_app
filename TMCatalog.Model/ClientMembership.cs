using System;
using System.ComponentModel.DataAnnotations;

namespace TMCatalog.Model
{
    public class ClientMembership
    {
        [Key]
        public int Id { get; set; }

        public int ClientId { get; set; }

        public int TicketId { get; set; }

        public DateTime ValidAfter { get; set; }

        public int EntranceLeft { get; set; }

        public int SoldBy { get; set; }

        public DateTime SoldOn { get; set; }

        public bool Active { get; set; }

        public float Price { get; set; }

        public string Comment { get; set; }
    }
}

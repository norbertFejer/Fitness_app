using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMCatalog.Model
{
    public class Entrance
    {
        [Key]
        public int Id { get; set; }

        public int ClientMembershipId { get; set; }

        public ClientMembership ClientMembership { get; set; }

        public DateTime ArrivedTime { get; set; }

        public DateTime LeftTime { get; set; }
    }
}

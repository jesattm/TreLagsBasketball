using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Model
{
    public class SponsorshipDetail
    {
        public int SponsorshipId { get; set; }
        public string SponsorshipName { get; set; }
        public virtual List<Player> Players { get; set; }
    }
}

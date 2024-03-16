using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_GUI_For_API.Model
{
    internal class SponsorshipDetail
    {
        public int sponsorshipDetailId { get; set; }
        public string sponsorshipDetailName { get; set; }
        public virtual List<PlayerDetail> players { get; set; }
        public override string? ToString()
        {
            return $"{sponsorshipDetailId}, Id: {sponsorshipDetailName}";
        }
    }
}

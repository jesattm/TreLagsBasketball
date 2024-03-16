using DTO.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_GUI_For_API.Model
{
    internal class Team
    {
        public int teamId { get; set; }
        public string teamName { get; set; }
        public List<PlayerDetail> players { get; set; }

        public override string? ToString()
        {
            return $"{teamName}, Id: {teamId}";
        }
    }
}

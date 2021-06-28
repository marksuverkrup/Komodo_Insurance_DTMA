using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POCO
{
    public class DevTeam
    {
        public List<Developer> TeamMembers { get; set; } = new List<Developer>();

        public string TeamName { get; set; }
        public int TeamId { get; set; }

        public DevTeam() { }

        public DevTeam(string teamName, int teamId)
        {
            TeamName = teamName;
            TeamId = teamId;
        }

        public void AddDeveloperToTeam(Developer newDeveloper)
        {
            TeamMembers.Add(newDeveloper);
        }
    }
}

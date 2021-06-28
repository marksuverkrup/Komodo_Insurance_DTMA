using POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class DevTeamRepo
    {
        protected readonly List<DevTeam> _devTeamDirectory = new List<DevTeam>();

        public bool AddDevTeamToDirectory(DevTeam newDevTeam)
        {
            int startingCount = _devTeamDirectory.Count;
            _devTeamDirectory.Add(newDevTeam);
            bool wasAdded = (_devTeamDirectory.Count > startingCount) ? true : false;
            return wasAdded;
        }

        public List<DevTeam> GetDevTeams()
        {
            return _devTeamDirectory;
        }

        public DevTeam GetDevTeamByName(string teamName)
        {
            foreach (DevTeam content in _devTeamDirectory)
            {
                if (content.TeamName.ToLower() == teamName.ToLower())
                {
                    return content;
                }
            }
            return null;
        }
    }
}

using POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class DeveloperRepo
    {
        protected readonly List<Developer> _developerDirectory = new List<Developer>();

        public bool AddDeveloperToDirectory(Developer newDeveloper)
        {
            int startingCount = _developerDirectory.Count;
            _developerDirectory.Add(newDeveloper);
            bool wasAdded = (_developerDirectory.Count > startingCount) ? true : false;
            return wasAdded;
        }

        public List<Developer> GetDevelopers()
        {
            return _developerDirectory;
        }

        public Developer GetDeveloperByName(string fullName)
        {
            foreach(Developer content in _developerDirectory)
            {
                if (content.FullName.ToLower() == fullName.ToLower())
                {
                    return content;
                }
            }
            return null;
        }
    }
}

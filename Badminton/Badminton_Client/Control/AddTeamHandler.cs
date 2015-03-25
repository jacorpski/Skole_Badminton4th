using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Badminton_Client.Model;

namespace Badminton_Client.Control
{
    public class AddTeamHandler
    {
        private TeamCatalog _teamCatalog;

        public AddTeamHandler()
        {
            _teamCatalog = new TeamCatalog();
        }

        public void AddTeam(string name)
        {
            _teamCatalog.AddTeam(new Team(name));
        }
    }
}

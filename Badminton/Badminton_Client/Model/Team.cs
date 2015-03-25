using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Badminton_Client.Model
{
    public class Team
    {
        private int _teamId;
        private string _name;

        public Team(string name)
        {
            Name = name;
        }

        public int TeamId
        {
            get { return _teamId; }
            set { _teamId = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }


    }
}

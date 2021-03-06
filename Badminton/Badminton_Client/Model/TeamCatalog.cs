﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Badminton_Client.BadmintonService;

namespace Badminton_Client.Model
{
    public class TeamCatalog
    {
        private ICollection<Team> _catalog;

        public TeamCatalog()
        {
            _catalog = new List<Team>();
        }

        public void AddTeam(Team team)
        {
            _catalog.Add(team);

            DatabaseRESTSoapClient soapClient = new DatabaseRESTSoapClient();

            int result = soapClient.AddTeam(team.Name);

            if(result == 1)
            {
                MessageBox.Show("Holdet er nu tilføjet.");
            }
            else
            {
                MessageBox.Show("Der skete en uventet fejl");
            }
        }
    }
}

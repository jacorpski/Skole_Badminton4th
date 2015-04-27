using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Badminton_Client.Control;

namespace Badminton_Client
{
    /// <summary>
    /// Interaction logic for AssignTeam.xaml
    /// </summary>
    public partial class AssignTeam : Window
    {
        private string _email;
        private string _password;

        public AssignTeam(string email, string password)
        {
            InitializeComponent();

            assignTeamComboBox.Visibility = Visibility.Hidden;
            assignTeamComboBox.SelectedValuePath = "Tag";
            assignToTeam.Visibility = Visibility.Hidden;


            _email = email;
            _password = password;

            GetMembers();
        }

        private void AssignTeam_OnClosing(object sender, CancelEventArgs e)
        {
            MemberOverview memberOverview = new MemberOverview(_email, _password);
            memberOverview.Show();
        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void membersComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Item item = (Item)membersComboBox.SelectedItem;

            fullNameLabel.Content = item.Name + " - " + item.ID;

            assignTeamComboBox.Visibility = Visibility.Visible;
            assignToTeam.Visibility = Visibility.Visible;
            memberIDLabel.Content = item.ID;

            assignTeamComboBox.Items.Clear();

            GetTeams();
            GetMemberAssignedToTeam(item.teamID);
        }

        private void GetTeams()
        {
            AddMemberHandler addMemberHandler = new AddMemberHandler();

            List<String> teams = addMemberHandler.GetTeamList();
            ComboBoxItem item;

            item = new ComboBoxItem();

            item.Tag = "0";
            item.Content = "(Ikke tildelt noget hold)";

            assignTeamComboBox.Items.Add(item);

            foreach (string team in teams)
            {
                string[] teamSplit = team.Split(',');

                item = new ComboBoxItem();

                item.Tag = teamSplit[0];
                item.Content = teamSplit[1];

                assignTeamComboBox.Items.Add(item);
            }
        }

        private void GetMemberAssignedToTeam(string teamID)
        {
            assignTeamComboBox.SelectedValue = teamID;
        }

        private void GetMembers()
        {
            AddMemberHandler addMemberHandler = new AddMemberHandler();

            List<String> members = addMemberHandler.GetMemberList();

            int i = 1;

            foreach (string member in members)
            {
                string[] memberSplit = member.Split(',');

                membersComboBox.Items.Add(new Item(memberSplit[0], memberSplit[1], memberSplit[2]));

                i++;
            }
        }

        private void assignToTeam_Click(object sender, RoutedEventArgs e)
        {
            int teamId = Convert.ToInt32(assignTeamComboBox.SelectedValue);
            int memberId = Convert.ToInt32(memberIDLabel.Content);

            AddMemberHandler addMemberHandler = new AddMemberHandler();

            addMemberHandler.AssignMemberToTeam(memberId, teamId);

        }

        private class Item
        {
            public string teamID;
            public string ID;
            public string Name;

            public Item(string team, string id, string name)
            {
                teamID = team;
                ID = id;
                Name = name;
            }

            public override string ToString()
            {
                return Name;
            }
        }
    }
}

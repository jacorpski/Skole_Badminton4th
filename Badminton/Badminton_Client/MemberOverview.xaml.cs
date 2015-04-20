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
    /// Interaction logic for MemberOverview.xaml
    /// </summary>
    public partial class MemberOverview : Window
    {
        private string _email;
        private string _password;

        private int _memberActivity;

        private AddMemberHandler _addMemberHandler = new AddMemberHandler();

        public MemberOverview(string email, string password)
        {
            InitializeComponent();

            _email = email;
            _password = password;

            GetActivity();
            IsAdmin();
        }

        private void GetActivity()
        {
            int memberActivity = _addMemberHandler.GetMemberActivity(_email, _password);

            if (memberActivity == 1)
            {
                activityLabel.Content = "Du er aktiv";
                activityButton.Content = "Sæt dig som inaktiv";
            }
            else if (memberActivity == 0)
            {
                activityLabel.Content = "Du er ikke aktiv";
                activityButton.Content = "Sæt dig som aktiv";
            }
            else
            {
                MessageBox.Show("Der skete en fejl");
            }

            _memberActivity = memberActivity;
        }

        public void IsAdmin()
        {
            int adminRights = _addMemberHandler.GetAdminRights(_email, _password);

            if (adminRights == 0)
            {
                addTeamButton.Visibility = Visibility.Hidden;
            }
        }

        private void activityButton_Click(object sender, RoutedEventArgs e)
        {
            if (_memberActivity == 1)
            {
                int result = _addMemberHandler.SetMemberAsInactive(_email, _password);

                if (result == 1)
                {
                    GetActivity();

                    MessageBox.Show("Du er nu inaktiv");
                }
            }
            else if (_memberActivity == 0)
            {
                MessageBox.Show("Du er nu aktiv");
            }
            else
            {
                MessageBox.Show("Der skete en fejl");
            }
        }

        private void MemberOverview_OnClosing(object sender, CancelEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
        }

        private void addTeamButton_Click(object sender, RoutedEventArgs e)
        {
            AddTeam addTeam = new AddTeam(_email, _password);
            addTeam.Show();
            Visibility = Visibility.Hidden;
        }

        private void logoutButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}

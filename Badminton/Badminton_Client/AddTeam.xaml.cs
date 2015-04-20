using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
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
    /// Interaction logic for AddTeam.xaml
    /// </summary>
    public partial class AddTeam : Window
    {
        private string _email;
        private string _password;

        public AddTeam(string email, string password)
        {
            InitializeComponent();

            _email = email;
            _password = password;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string name = nameText.Text;

            AddTeamHandler addTeamHandler = new AddTeamHandler();

            addTeamHandler.AddTeam(name);
        }

        private void AddTeam_OnClosing(object sender, CancelEventArgs e)
        {
            MemberOverview memberOverview = new MemberOverview(_email, _password);
            memberOverview.Show();
        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}

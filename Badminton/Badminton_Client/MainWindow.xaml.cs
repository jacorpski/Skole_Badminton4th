using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Badminton_Client.BadmintonService;
using Badminton_Client.Control;

namespace Badminton_Client
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        /*private void Button_Click(object sender, RoutedEventArgs e)
        {
            AddMember addMember = new AddMember();
            addMember.Show();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            AddTeam addTeam = new AddTeam();
            addTeam.Show();
            this.Close();
        }*/

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            string email = emailTextbox.Text;
            string password = passwordTextbox.Password;
            
            AddMemberHandler addMemberHandler = new AddMemberHandler();

            int result = addMemberHandler.LoginMember(email, password);

            if (result == 1)
            {
                MemberOverview memberOverview = new MemberOverview(email, password);
                memberOverview.Show();
                this.Close();
            }
            else if (result == 2)
            {
                MessageBox.Show("Fejl!");
            }
            else
            {
                MessageBox.Show("Der skete en uventet fejl.");
            }
        }
    }
}

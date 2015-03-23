using System;
using System.Collections.Generic;
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string firstName = firstNameText.Text;
            string surName = surNameText.Text;
            int cpr = Convert.ToInt32(cprText.Text);
            string address = addressText.Text;
            int zipCode = Convert.ToInt32(zipCodeText.Text);
            string phone = phoneText.Text;
            string mail = mailText.Text;

            AddMemberHandler addMemberHandler = new AddMemberHandler();

            addMemberHandler.AddMember(firstName, surName, cpr, address, zipCode, phone, mail);
        }
    }
}

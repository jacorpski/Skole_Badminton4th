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
            int medlemsId = Convert.ToInt32(medlemsidText.Text);
            string fornavn = fornavnText.Text;
            string efternavn = efternavnText.Text;
            string fodselsdato = fodselsdatotext.Text;
            string adresse = adresseText.Text;
            int postnr = Convert.ToInt32(postNrText.Text);
            string telefon = telefonText.Text;
            string email = emailText.Text;

            DatabaseRESTSoapClient service = new DatabaseRESTSoapClient();

            service.AddUser(medlemsId, fornavn, efternavn, fodselsdato, adresse, postnr, telefon, email);

            MessageBox.Show("Medlemmet er nu tilføjet til databasen.");
        }
    }
}

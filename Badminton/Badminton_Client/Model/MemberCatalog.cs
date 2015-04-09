using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Badminton_Client.BadmintonService;

namespace Badminton_Client
{
    public class MemberCatalog
    {
        private ICollection<Member> _catalog;

        public MemberCatalog()
        {
            _catalog = new List<Member>();
        }

        public void AddMember(Member member)
        {
            _catalog.Add(member);

            DatabaseRESTSoapClient soapClient = new DatabaseRESTSoapClient();

            int result = soapClient.AddMember(member.FirstName, member.SurName, member.Password, member.Cpr, member.Address,
                member.ZipCode, member.Phone, member.Mail);

            if (result == 1)
            {
                MessageBox.Show("Medlemmet er nu tilføjet til databasen.");
            }
            else if (result == 4)
            {
                MessageBox.Show("CPR nummeret eksistere allerede.");
            }
            else
            {
                MessageBox.Show("Der skete en uventet fejl.");
            }
        }

        public void SetMemberAsInactive(int memberId)
        {
            //Contact webservice here
        }

        public int LoginMember(string email, string password)
        {
            DatabaseRESTSoapClient soapClient = new DatabaseRESTSoapClient();

            return soapClient.LoginMember(email, password);
        }
    }
}

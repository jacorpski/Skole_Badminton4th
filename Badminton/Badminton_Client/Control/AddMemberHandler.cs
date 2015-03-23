using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Badminton_Client.BadmintonService;

namespace Badminton_Client.Control
{
    public class AddMemberHandler
    {
        private MemberCatalog _memberCatalog;

        public AddMemberHandler()
        {
            _memberCatalog = new MemberCatalog();
        }

        public void AddMember(string firstName, string surName, string cpr, string address, string zipCode, string phone, string mail)
        {
            _memberCatalog.AddMember(new Member(firstName, surName, cpr, address, zipCode, phone, mail));
        }
    }
}

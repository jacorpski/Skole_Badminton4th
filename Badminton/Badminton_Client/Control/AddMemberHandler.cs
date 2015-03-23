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
<<<<<<< HEAD
        public void AddMember(string firstName, string surName, string cpr, string address, string zipCode, string phone, string mail)
=======
        public void AddMember(bool isActive, string firstName, string surName, string cpr, string address, string zipCode, string phone, string mail)
>>>>>>> df9ebde09fa9f0035d920b4b095f025d1143f81a
        {
            _memberCatalog.AddMember(new Member(firstName, surName, cpr, address, zipCode, phone, mail));
        }

        public void SetMemberAsInactive(int memberId)
        {
            _memberCatalog.SetMemberAsInactive(memberId);
        }
    }
}

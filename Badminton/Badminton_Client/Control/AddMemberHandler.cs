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

        public void AddMember(string firstName, string surName, string password, string cpr, string address, string zipCode, string phone, string mail)
        {
            _memberCatalog.AddMember(new Member(firstName, surName, password, cpr, address, zipCode, phone, mail));
        }

        public void SetMemberAsInactive(int memberId)
        {
            _memberCatalog.SetMemberAsInactive(memberId);
        }

        public void AssignMemberToTeam(int memberId, int teamId)
        {
            _memberCatalog.AssignMemberToTeam(memberId, teamId);
        }
    }
}

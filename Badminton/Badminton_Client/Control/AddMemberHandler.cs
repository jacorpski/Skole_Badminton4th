using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
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

        public int SetMemberAsInactive(string email, string password)
        {
            return _memberCatalog.SetMemberAsInactive(email, password);
        }

        public int GetMemberActivity(string email, string password)
        {
            return _memberCatalog.GetMemberActivity(email, password);
        }

        public int GetAdminRights(string email, string password)
        {
            return _memberCatalog.GetAdminRights(email, password);
        }

        public int LoginMember(string email, string password)
        {
            return _memberCatalog.LoginMember(email, password);
        }

        public void AssignMemberToTeam(int memberId, int teamId)
        {
            _memberCatalog.AssignMemberToTeam(memberId, teamId);
        }

        public List<String> GetMemberList()
        {
            return _memberCatalog.GetMemberList();
        }

        public List<String> GetTeamList()
        {
            return _memberCatalog.GetTeamList();
        } 
    }
}

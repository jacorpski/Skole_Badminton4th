using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Badminton_Client.Control
{
    public class AddMemberHandler
    {
        private MemberCatalog _memberCatalog;

        public AddMemberHandler()
        {
            _memberCatalog = new MemberCatalog();
        }

        public void AddMember(bool isActive, string firstName, string surName, int cpr, string address, int zipCode, string phone, string mail)
        {
            _memberCatalog.AddMember(new Member(isActive, firstName, surName, cpr, address, zipCode, phone, mail));
        }

        public void SetMemberAsInactive(int memberId)
        {
            _memberCatalog.SetMemberAsInactive(memberId);
        }
    }
}

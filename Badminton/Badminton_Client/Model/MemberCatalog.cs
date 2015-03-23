using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        }
    }
}

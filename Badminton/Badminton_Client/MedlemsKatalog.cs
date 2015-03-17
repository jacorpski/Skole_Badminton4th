using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Badminton_Client
{
    public class MedlemsKatalog
    {
        private ICollection<Medlem> _katalog;

        public MedlemsKatalog()
        {
            _katalog = new List<Medlem>();
        }

        public void OpretMedlem(Medlem medlem)
        {
            _katalog.Add(medlem);
        }
    }
}

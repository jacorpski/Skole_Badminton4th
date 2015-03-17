using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Badminton_Client.Control
{
    public class OpretMedlemHandler
    {
        private MedlemsKatalog _medlemsKatalog;

        public OpretMedlemHandler()
        {
            _medlemsKatalog = new MedlemsKatalog();
        }

        public void OpretMedlem(int medlemsId, string fornavn, string efternavn, DateTime fødselsdato, string addresse, int postNr, string telefon, string mail)
        {
            _medlemsKatalog.OpretMedlem(new Medlem(medlemsId, fornavn, efternavn, fødselsdato, addresse, postNr, telefon, mail));
        }
    }
}

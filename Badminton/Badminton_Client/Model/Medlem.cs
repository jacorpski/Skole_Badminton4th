﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Badminton_Client
{
    public class Medlem
    {
        private int _medlemsId;
        private string _fornavn;
        private string _efternavn;
        private DateTime _fødselsDato;
        private string _addresse;
        private int _postNr;
        private string _telefon;
        private string _mail;

        public Medlem(int medlemsId, string navn, string efternavn, DateTime fødselsDato, string addresse, int postNr, string telefon, string mail)
        {
            _medlemsId = medlemsId;
            _fornavn = navn;
            _efternavn = efternavn;
            _fødselsDato = fødselsDato;
            _addresse = addresse;
            _postNr = postNr;
            _telefon = telefon;
            _mail = mail;
        }

        public int MedlemsId
        {
            get { return _medlemsId; }
            set { _medlemsId = value; }
        }

        public string Navn
        {
            get { return _fornavn; }
            set { _fornavn = value; }
        }

        public string Efternavn
        {
            get { return _efternavn; }
            set { _efternavn = value; }
        }

        public DateTime FødselsDato
        {
            get { return _fødselsDato; }
            set { _fødselsDato = value; }
        }

        public string Addresse
        {
            get { return _addresse; }
            set { _addresse = value; }
        }

        public int PostNr
        {
            get { return _postNr; }
            set { _postNr = value; }
        }

        public string Telefon
        {
            get { return _telefon; }
            set { _telefon = value; }
        }

        public string Mail
        {
            get { return _mail; }
            set { _mail = value; }
        }

        public override string ToString()
        {
            return string.Format("Medlems Id: {0}, Navn: {1} {2}", _medlemsId, _fornavn, _efternavn);
        }
    }
}
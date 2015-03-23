using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Badminton_Client
{
    public class Member
    {
        private int _memberId;
        private bool _isActive;
        private string _firstName;
        private string _surName;
        private string _cpr;
        private string _address;
        private string _zipCode;
        private string _phone;
        private string _mail;

        public Member(bool isActive, string firstName, string surName, string cpr, string address, string zipCode, string phone, string mail, int memberId = 0)
        {
            _isActive = isActive;
            _firstName = firstName;
            _surName = surName;
            _cpr = cpr;
            _address = address;
            _zipCode = zipCode;
            _phone = phone;
            _mail = mail;
        }

        public Member(string firstName, string surName, string cpr, string address, string zipCode, string phone, string mail, int memberId = 0)
        {
            _firstName = firstName;
            _surName = surName;
            _cpr = cpr;
            _address = address;
            _zipCode = zipCode;
            _phone = phone;
            _mail = mail;
        }

        public int MemberId
        {
            get { return _memberId; }
            set { _memberId = value; }
        }

        public bool IsActive
        {
            get { return _isActive; }
            set { _isActive = value; }
        }

        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = value; }
        }

        public string SurName
        {
            get { return _surName; }
            set { _surName = value; }
        }

        public string Cpr
        {
            get { return _cpr; }
            set { _cpr = value; }
        }

        public string Address
        {
            get { return _address; }
            set { _address = value; }
        }

        public string ZipCode
        {
            get { return _zipCode; }
            set { _zipCode = value; }
        }

        public string Phone
        {
            get { return _phone; }
            set { _phone = value; }
        }

        public string Mail
        {
            get { return _mail; }
            set { _mail = value; }
        }

        public override string ToString()
        {
            return string.Format("Navn: {0} {1}", _firstName, _surName);
        }
    }
}

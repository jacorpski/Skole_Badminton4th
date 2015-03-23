using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Badminton_Client
{
    public class Member
    {
        private string _firstName;
        private string _surName;
        private int _cpr;
        private string _address;
        private int _zipCode;
        private string _phone;
        private string _mail;

        public Member(string firstName, string surName, int cpr, string address, int zipCode, string phone, string mail)
        {
            _firstName = firstName;
            _surName = surName;
            _cpr = cpr;
            _address = address;
            _zipCode = zipCode;
            _phone = phone;
            _mail = mail;
        }

        public string FirstName
        {
            get { return _firstName; }
            set
            {
                if (value != null && value != "")
                {
                    _firstName = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Empty or null not allowed" + value);
                }
            }
        }

        public string SurName
        {
            get { return _surName; }
            set
            {
                if (value != null && value != "")
                {
                    _surName = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Empty or null not allowed" + value);
                }
            }
        }

        public int Cpr
        {
            get { return _cpr; }
            set
            {
                if (value != null && value >= 1000000000 && value <= 9999999999)
                {
                    _cpr = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Empty or null not allowed and must be 10 digits" + value);
                }
            }
        }

        public string Address
        {
            get { return _address; }
            set
            {
                if (value != null && value != "")
                {
                    _address = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Empty or null not allowed" + value);
                }
            }
        }

        public int ZipCode
        {
            get { return _zipCode; }
            set
            {
                if (value != null && value >= 1000 && value <= 9999)
                {
                    _zipCode = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Empty or null not allowed and must be 4 digits" + value);
                }
            }
        }

        public string Phone
        {
            get { return _phone; }
            set
            {
                if (value != null && value != "" && value.Length == 8)
                {
                    _phone = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Empty or null not allowed and must contain 8 digits" + value);
                }
            }
        }

        public string Mail
        {
            get { return _mail; }
            set
            {
                string pattern = "^([0-9a-zA-Z]([-\\.\\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$";

                if (value != null && value != "" && Regex.IsMatch(value, pattern))
                {
                    _mail = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Empty or null not allowed and must be correct format" + value);
                }
            }
        }

        public override string ToString()
        {
            return string.Format("Navn: {0} {1}", _firstName, _surName);
        }
    }
}

﻿using System;
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
        private string _cpr;
        private string _address;
        private string _zipCode;
        private string _phone;
        private string _mail;

        public Member(string firstName, string surName, string cpr, string address, string zipCode, string phone, string mail)
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
                if (!string.IsNullOrEmpty(value))
                {
                    _firstName = value;
                }
                else
                {
                    throw new ArgumentException("Empty or null not allowed" + value);
                }
            }
        }

        public string SurName
        {
            get { return _surName; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    _surName = value;
                }
                else
                {
                    throw new ArgumentException("Empty or null not allowed" + value);
                }
            }
        }

        public string Cpr
        {
            get { return _cpr; }
            set
            {
                if (!string.IsNullOrEmpty(value) && value.Length == 10)
                {
                    _cpr = value;
                }
                else
                {
                    throw new ArgumentException("Empty or null not allowed and must be 10 digits" + value);
                }
            }
        }

        public string Address
        {
            get { return _address; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    _address = value;
                }
                else
                {
                    throw new ArgumentException("Empty or null not allowed" + value);
                }
            }
        }

        public string ZipCode
        {
            get { return _zipCode; }
            set
            {
                if (!string.IsNullOrEmpty(value) && value.Length == 4)
                {
                    _zipCode = value;
                }
                else
                {
                    throw new ArgumentException("Empty or null not allowed and must be 4 digits" + value);
                }
            }
        }

        public string Phone
        {
            get { return _phone; }
            set
            {
                if (!string.IsNullOrEmpty(value) && value.Length == 8)
                {
                    _phone = value;
                }
                else
                {
                    throw new ArgumentException("Empty or null not allowed and must contain 8 digits" + value);
                }
            }
        }

        public string Mail
        {
            get { return _mail; }
            set
            {
                string pattern = "^([0-9a-zA-Z]([-\\.\\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$";

                if (!string.IsNullOrEmpty(value) && Regex.IsMatch(value, pattern))
                {
                    _mail = value;
                }
                else
                {
                    throw new ArgumentException("Empty or null not allowed and must be correct format" + value);
                }
            }
        }

        public override string ToString()
        {
            return string.Format("Navn: {0} {1}", _firstName, _surName);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company
{
    class Employee
    {
        private int _id = 0;
        private string _firstName;
        private string _lastName;
        private DateTime _startDate;
        private DateTime _birthday;
        private string _email;

        public Employee(string firstName, string lastName, DateTime startDate, DateTime birthday, string email)
        {
            this._id += 1;
            this._firstName = firstName;
            this._lastName = lastName;
            this._startDate = startDate;
            this._birthday = birthday;
            this._email = email;
        }

        public int ID
        {
            get
            {
                return this._id;
            }
        }

        public string FirstName
        {
            get
            {
                return this._firstName;
            }
        }

        public string LastName
        {
            get
            {
                return this._lastName;
            }
        }

        public DateTime StartDate
        {
            get
            {
                return this._startDate;
            }
        }

        public DateTime Birthday
        {
            get
            {
                return this._birthday;
            }
        }

        public string Email
        {
            get
            {
                return this._email;
            }
        }
    }
}

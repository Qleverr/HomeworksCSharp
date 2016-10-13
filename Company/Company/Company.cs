using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company
{
    class Company
    {
        private int _id = 0;
        private string _name;
        private string _city;
        private List<Factory> _factories;

        public Company(string name, string city, List<Factory> factories)
        {
            this._id += 1;
            this._name = name;
            this._city = city;
            this._factories = factories;
        }

        public int ID
        {
            get
            {
                return this._id;
            }
        }

        public string Name
        {
            get
            {
                return this._name;
            }
        }

        public string City
        {
            get
            {
                return this._city;
            }
        }

        public List<Factory> Factories
        {
            get
            {
                return this._factories;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company
{
    class Factory
    {
        private int _id = 0;
        private string _city;
        private DateTime _builtDate;
        private List<Employee> _employees;
        private List<Machine> _machines;
        private List<Product> _products;

        public Factory(string city, DateTime builtDate, List<Employee> employees, List<Machine> machines, List<Product> products)
        {
            this._id += 1;
            this._city = city;
            this._builtDate = builtDate;
            this._employees = employees;
            this._machines = machines;
            this._products = products;
        }

        public int ID
        {
            get
            {
                return this._id;
            }
        }

        public string City
        {
            get
            {
                return this._city;
            }
        }

        public DateTime builtDate
        {
            get
            {
                return this._builtDate;
            }
        }

        public List<Employee> Employees
        {
            get
            {
                return this._employees;
            }
        }

        public List<Machine> Machines
        {
            get
            {
                return this._machines;
            }
        }

        public List<Product> Products
        {
            get
            {
                return this._products;
            }
        }
    }
}

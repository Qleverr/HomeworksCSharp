using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company
{
    class Product
    {
        private int _id = 0;
        private DateTime _creationDate;
        private bool _defect;
        private int _lot;

        public Product(DateTime creationDate, bool defect, int lot)
        {
            this._id += 1;
            this._creationDate = creationDate;
            this._defect = defect;
            this._lot = lot;
        }

        public int ID
        {
            get
            {
                return this._id;
            }
        }

        public DateTime CreationDate
        {
            get
            {
                return this._creationDate;
            }
        }

        public bool Defect
        {
            get
            {
                return this._defect;
            }
        }

        public int Lot
        {
            get
            {
                return this._lot;
            }
        }
    }
}

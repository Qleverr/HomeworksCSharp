using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company
{
    class Machine
    {
        private int _id = 0;
        private DateTime _purchaseDate;
        private DateTime _lastFixDate;

        public Machine(DateTime purchaseDate, DateTime lastFixDate)
        {
            this._id += 1;
            this._purchaseDate = purchaseDate;
            this._lastFixDate = lastFixDate;
        }

        public int ID
        {
            get
            {
                return this._id;
            }
        }

        public DateTime PurchaseDate
        {
            get
            {
                return this._purchaseDate;
            }
        }

        public DateTime LastFixDate
        {
            get
            {
                return this._lastFixDate;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parking_Camp
{
    class Transaction
    {
        private string _id;
        private double _spentfounds;
        public DateTime DateTimeOfTransaction = new DateTime();

        // Properties
        public string Id
        {
            get { return _id; }
            set
            {
                if (_id == null)
                    _id = value;
            }
        }
        public double SpentFunds
        {
            get { return _spentfounds; }
            set { _spentfounds = value; }
        }

        // ctors
        public Transaction()
        {

        }

        public Transaction(string id, double spentfounds)
        {
            DateTimeOfTransaction = DateTime.Now;
            Id = id;
            SpentFunds = spentfounds;
        }

       
        public override string ToString()
        {
            return String.Format($"Time of Transac: {DateTimeOfTransaction}\tId: {Id}\tSpend Founds: {SpentFunds}");
        }
    }
}

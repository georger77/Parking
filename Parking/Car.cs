using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parking_Camp
{
    class Car
    {
        // fields
        private string _id;
        // Properties
        public CarType CarType { get; private set; }

        public double Balance { get; private set; }
        public string Id
        {
            get { return _id; }
            private set
            {
                if (_id == null)
                    _id = value;
            }
        }
        // ctors
        public Car()
        {
        }


        public Car(CarType carType, string id, double balance)

        {
            Id = id;
            CarType = carType;
            Balance = balance;
        }

       


       

        // Methods
        public void IncreaseBalance(double sumIncrease, bool IsAdding)
        {
            if (sumIncrease < 0)
                return;

            if (IsAdding == true)
                Balance += sumIncrease;
            else
                Balance -= sumIncrease;
        }
        public override string ToString()
        {
            return String.Format($"Type: {CarType.ToString()}\tId: {Id}\tBalance:{Balance}");
        }
    }
}

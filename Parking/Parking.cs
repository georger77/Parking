using Parking_Camp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Parking_Camp
{
    class Parking
    {
        private static readonly Lazy<Parking> instance = new Lazy<Parking>(() => new Parking());
        private int _parkingSpace;
        private List<Transaction> _transactions;
        private DateTime _dateOfLog;
        private List<Car> _cars;
        public Parking()
        {
            _parkingSpace = Settings._parkingSpace;
            _transactions = new List<Transaction>();
            _dateOfLog = DateTime.Now;
            _cars = new List<Car>();
        }

        public double Balance { get; private set; }
        public static Parking Instance { get { return instance.Value; } }
        
        ////    Add car to the parking
        public void AddCar(Car car)
        {
            if (_parkingSpace > 0)
            {
               
                _parkingSpace--;
                _cars.Add(car);
            }
            void IncreaseBalanceCarByTimer(Object obj)
            {

                if (car.Balance > Settings._price[car.CarType.ToString()])
                {
                    car.IncreaseBalance(Settings._price[car.CarType.ToString()], false);
                    _transactions.Add(new Transaction(car.Id, Settings._price[car.CarType.ToString()]));
                    Balance += Settings._price[car.CarType.ToString()];
                }
                else
                {
                    car.IncreaseBalance(Settings._price[car.CarType.ToString()] * Settings._fine, false);
                    _transactions.Add(new Transaction(car.Id, Settings._price[car.CarType.ToString()] * Settings._fine));
                    Balance += Settings._price[car.CarType.ToString()] * Settings._fine;
                }
            }
            TimerCallback tm = new TimerCallback(IncreaseBalanceCarByTimer);
            Timer timer = new Timer(tm, null, 0, Settings._timeout);
            WriteLog();
        }

        ////    Remove car from the parking by object Car
        public void RemoveCar(Car car)
        {
            if ( _cars.Contains(car))
            {
               
                _parkingSpace++;
                _cars.Remove(car);
            }
        }
        ////    Remove car from the parking by Id Car
        public void RemoveCarById(string idCar)
        {
            int count = 0;
            Car _car = new Car();
            foreach (var x in _cars)
            {
                if (x.Id == idCar) { _car = x;
                    count++;
                }
            }
            if (count > 0)
            {
                int n = _cars.IndexOf(_car);
                if (_cars[n].Balance >= 0)
                { _cars.Remove(_car); }
                else
                {
                    Console.WriteLine("Your account is not positive");
                    Console.WriteLine($"You must pay not less {(-1) * _cars[n].Balance} $");
                }
            }
            else
            {
                Console.WriteLine("Uncorrect IdCar");

            }

        }


        ////    Increase cars balance  by Id Car
        public void IncreaseBalanceCarById(string idCar, double sum, bool y)
        {
            int count = 0;
            Car _car = new Car();
            foreach (var x in _cars)
            {
                if (x.Id == idCar) { _car = x;
                    count++;
                }
            }
            if (count > 0)
            {
                int n = _cars.IndexOf(_car);
                _cars[n].IncreaseBalance(sum, y);
            }
            else { Console.WriteLine("Uncorrect IdCar");

            }
        }
        ////    Show Balance of the parking
        public string ShowBalance()
        {
            return String.Format("The balance of parking: {0}", Balance);
        }
        ////    Find Count of free places
        public string CountOfFreePlaces()
        {
            if (_parkingSpace > 1)
                return String.Format("There are {0} free places in this parking!", _parkingSpace);
            else if (_parkingSpace == 0)
                return String.Format("There isn't any free place in parking");
            else
                return String.Format("There is {0} free place in this parking!", _parkingSpace);
        }

        //Write every minute to the file Transactions.log sum of transactions with date of writing

        public void WriteLog()
        {

            void WriteSumTransactionsForLastMinute(Object obj)
            {
                double sum = 0;
                foreach (var x in _transactions)
                {
                    if ((DateTime.Now - x.DateTimeOfTransaction).TotalMinutes <= 1) sum += x.SpentFunds;
                }

                using (StreamWriter writer = File.AppendText(@"C:\Transactions.log"))
                {

                    writer.WriteLine("Log Entry : ");
                    writer.WriteLine("\r\nDate: {0}", DateTime.Now.ToString());
                    writer.WriteLine("Sum of transactions: {0}", sum);
                    writer.WriteLine("----------------------------\r\n");
                }

            }
            TimerCallback tm = new TimerCallback(WriteSumTransactionsForLastMinute);
            Timer timer = new Timer(tm, null, 0, 60000);

        }


        //Show to console data of  Transactions.log 
        public void ShowLog()
        {
            string[] data = File.ReadAllLines(@"C:\Transactions.log");

            foreach (string i in data) { Console.WriteLine(i); }

        }

        //Show the list of transactions of last minute 

        public void ShowTransactionsPerLastMinute()
        {

            foreach (var x in _transactions)
            {
                if ((DateTime.Now - x.DateTimeOfTransaction).TotalMinutes <= 1) Console.WriteLine(x);

            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            foreach (Car item in _cars)
            {
                sb.Append(item + "\r\n");
            }
            return String.Format(sb.ToString());
        }
    }
}


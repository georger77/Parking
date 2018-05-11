using Parking;
using Parking_Camp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Parking_Camp
{
    

    class Program
    {
        static void Main(string[] args)
        {
            Parking parking = new Parking();
           
            Console.WriteLine("Hello to you in our parking");

            Menu.Show();


            int choice = int.Parse(Console.ReadLine());
            for (; choice > 0 && choice < 8;)
            {
                switch (choice)
                {
                    case 1:
                        {
                            Console.WriteLine("We add new car");
                            Console.WriteLine("Make your choice about cars type and then press enter");
                            Console.WriteLine("0-Passenger,1- Truck,2- Bus,3- Motorcycle");
                            CarType type = (CarType)int.Parse(Console.ReadLine());
                            Console.WriteLine("Make your choice about cars id and then press enter");
                            Console.WriteLine("Format  of id is   XX12345XX");
                            string idCar = Console.ReadLine();
                            Console.WriteLine("Create a balance for your car in $");
                            double bal=0;
                            try
                            {
                                 bal = int.Parse(Console.ReadLine());
                            }
                            catch (FormatException ex)
                            {
                                Console.WriteLine(ex.Message);
                                Console.WriteLine(ex.Source);
                            }
                            catch (OverflowException ex)
                            {

                                Console.WriteLine(ex.Message);
                                Console.WriteLine(ex.Source);
                            }

                            Car car = new Car(type, idCar, bal);

                            parking.AddCar(car);

                        }
                        Menu.Show();
                        choice = int.Parse(Console.ReadLine());
                        break;
                    case 2:
                        {
                            Console.WriteLine("We want delete car");
                            Console.WriteLine("This is the list of our parking");
                            Console.WriteLine(parking);
                            Console.WriteLine("Make your choice about cars id and then press enter");
                            string idCar = Console.ReadLine();

                            parking.RemoveCarById(idCar);


                        }
                        Menu.Show();
                        choice = int.Parse(Console.ReadLine());
                        break;
                    case 3:
                        {
                            Console.WriteLine("We want increase cars balance");
                            Console.WriteLine("This is the list of our parking");
                            Console.WriteLine(parking);
                            Console.WriteLine("Make your choice about cars id and then press enter");
                            string idCar = Console.ReadLine();
                            Console.WriteLine("Make your choice about sum of increasing");
                            int z = int.Parse(Console.ReadLine());
                            parking.IncreaseBalanceCarById(idCar, z, true);


                        }
                        Menu.Show();
                        choice = int.Parse(Console.ReadLine());
                        break;
                    case 4:
                        {
                            Console.WriteLine("Transactions for last minute");
                            parking.ShowTransactionsPerLastMinute();

                        }
                        Menu.Show();
                        choice = int.Parse(Console.ReadLine());
                        break;

                    case 5:
                        {
                            Console.WriteLine("Parkings earnings");
                            Console.WriteLine(parking.ShowBalance());

                        }
                        Menu.Show();
                        choice = int.Parse(Console.ReadLine());
                        break;


                    case 6:
                        {
                            Console.WriteLine("Parkings free places");
                            Console.WriteLine(parking.CountOfFreePlaces());

                        }
                        Menu.Show();
                        choice = int.Parse(Console.ReadLine());
                        break;
                    case 7:
                        {
                            Console.WriteLine("Pull data from Transactions.log");
                            parking.ShowLog();

                        }
                        Menu.Show();
                        choice = int.Parse(Console.ReadLine());
                        break;



                    case 0:
                        Console.WriteLine("By!");
                        break;
                    default:
                        Console.WriteLine("Hello1Default");
                        break;
                }
            }

            Console.WriteLine(parking);


        }
    }
}

using System;
using System.Collections.Generic;

namespace Parking_Camp
{
    public static class Settings
    {

        public static readonly  int _parkingSpace=20;
        public static readonly double _fine=1.1;
        public static readonly int _timeout = 3000;

        public static readonly Dictionary<string, int> _price = new Dictionary<string, int>
        {
            {CarType.Truck.ToString(), 5 },
            {CarType.Passenger.ToString(), 3 },
            {CarType.Bus.ToString(), 2 },
            {CarType.Motorcycle.ToString(), 1 }
        };

      


    }
}

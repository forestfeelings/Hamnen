using System;
using System.Collections.Generic;

namespace Hamnen
{
    class Program
    {
        static void Main(string[] args)
        {
            Stevedore stevedore = new Stevedore(new Harbor());
            ShipBuilder shipBuilder = new ShipBuilder();

            int startingDay = 1;
            // Set day to end program
            int endingDay = 20;

            while (startingDay != endingDay)
            {
                stevedore.InitialiseDepartingBoats();
                Console.WriteLine($"Dag: {startingDay}");

                for (int i = 0; i < 5; i++)
                {
                    var newBoat = shipBuilder.GenerateBoat();
                    stevedore.DockBoat(newBoat);
                }
                stevedore.ShowHarborInfo();
                stevedore.DecrementDaysInHarbor();
                startingDay += 1;
                Console.ReadLine();
                Console.Clear();
            }

            Console.WriteLine("Hamnarbetet avslutas.");
        }

        
    }
}

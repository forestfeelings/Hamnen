using System;
using System.Collections.Generic;
using System.Linq;

namespace Hamnen
{
    public class Stevedore
    {
        private readonly Harbor Harbor;
        List<Boat> RejectedBoats = new List<Boat>();

        public Stevedore(Harbor harbor)
        {
            Harbor = harbor;
        }

        public void ShowHarborInfo()
        {
            var boatsInHarbor = Harbor.BoatsInHarbor();
            var availablePorts = 0;
            Console.WriteLine("Plats\tBåttyp\t\tReg.Nr.");
            for (int port = 0; port < boatsInHarbor.Length; port++)
            {
                
                if (boatsInHarbor[port] == null)
                {
                    availablePorts += 1;
                    Console.WriteLine($"{port + 1}\tTom");
                }
                // Checks the boat is unique and avoids index out of bounds by excluding second to last port
                else if (port != boatsInHarbor.Length - 1 && boatsInHarbor[port] != boatsInHarbor[port + 1])
                {
                    // Separates boats taking up multiple ports
                    if (boatsInHarbor[port].PortSpaceOccupied.Count > 1)
                    {
                        Console.WriteLine($"{boatsInHarbor[port].PortSpaceOccupied.FirstOrDefault() + 1}-" +
                            $"{boatsInHarbor[port].PortSpaceOccupied.LastOrDefault() + 1}" +
                            $"\t{boatsInHarbor[port].Type}\t{boatsInHarbor[port].Name}");
                    }
                    else
                    {
                        Console.WriteLine($"{boatsInHarbor[port].PortSpaceOccupied.FirstOrDefault() + 1}" +
                            $"\t{boatsInHarbor[port].Type}\t{boatsInHarbor[port].Name}");
                    }
                    
                }
                // Checks if it's the second to last port
                else if (port == boatsInHarbor.Length - 1)
                {
                    if (boatsInHarbor[port].PortSpaceOccupied.Count > 1)
                    {
                        // Separates boats taking up multiple ports
                        Console.WriteLine($"{boatsInHarbor[port].PortSpaceOccupied.FirstOrDefault() + 1}-" +
                            $"{boatsInHarbor[port].PortSpaceOccupied.LastOrDefault() + 1}" +
                            $"\t{boatsInHarbor[port].Type}\t{boatsInHarbor[port].Name}");
                    }
                    else
                    {
                        Console.WriteLine($"{boatsInHarbor[port].PortSpaceOccupied.FirstOrDefault() + 1}" +
                            $"\t{boatsInHarbor[port].Type}\t{boatsInHarbor[port].Name}");
                    }
                }
            }
            Console.WriteLine($"Lediga platser i hamnen: {availablePorts}");
            Console.WriteLine($"Antalet avvisade båtar: {RejectedBoats.Count}");
        }

        public void DockBoat(Boat boat)
        {
            var rejectedBoat = Harbor.DockBoatInAvailablePort(boat);
            if (rejectedBoat != null)
            {
                RejectedBoats.Add(rejectedBoat);
            }
        }

        public void InitialiseDepartingBoats()
        {
            var boatsInHarbor = Harbor.BoatsInHarbor();
            for (int i = 0; i < boatsInHarbor.Length; i++)
            {
                if (boatsInHarbor[i] == null)
                {
                    continue;
                }
                else if(boatsInHarbor[i].DaysLeftInHarbor == 0)
                {
                    Harbor.DepartBoatFromPort(i);
                }
            }
        }

        public void DecrementDaysInHarbor()
        {
            var harbor = Harbor.BoatsInHarbor();
            var boatsInHarbor = harbor.Distinct().ToList();

            foreach (var boatInHarbor in boatsInHarbor)
            {
                if (boatInHarbor == null)
                {
                    continue;
                }
                boatInHarbor.DaysLeftInHarbor -= 1;
            }
        }
    }
}
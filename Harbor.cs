using System;
using System.Collections.Generic;

namespace Hamnen
{
    public class Harbor
    {
        private Boat[] AvailablePorts = new Boat[25];

        public Boat DockBoatInAvailablePort(Boat boat)
        {
            for (int port = 0; port < AvailablePorts.Length; port++)
            {
                if (AvailablePorts[port] == null)
                {
                    bool enoughSpace = CheckPortSpace(port, boat.PortSpaceRequired);
                    if (enoughSpace)
                    {
                        DockBoatInPort(boat, port);
                        return null;
                    }
                }
            }
            return boat;
        }

        public Boat[] BoatsInHarbor()
        {
            return AvailablePorts;
        }

        public void DepartBoatFromPort(int port)
        {
            AvailablePorts[port] = null;
        }

        private void DockBoatInPort(Boat boat, int firstPort)
        {
            List<int> portSpaceOccupied = new List<int>();

            for (int i = 0; i < boat.PortSpaceRequired; i++)
            {
                portSpaceOccupied.Add(firstPort + i);
                AvailablePorts[firstPort + i] = boat;
            }

            boat.PortSpaceOccupied = portSpaceOccupied;
        }

        private bool CheckPortSpace(int firstPort, int portsRequired)
        {
            if (firstPort + portsRequired > AvailablePorts.Length)
            {
                return false;
            }
            int availablePorts = 0;
            for (int i = firstPort; i < firstPort + portsRequired; i++)
            {
                //Port is occupied
                if (AvailablePorts[i] != null)
                {
                    return false;
                }
                availablePorts += 1;
            }
            //Count subsequent ports and check if it matches with ports required
            if (availablePorts == portsRequired)
            {
                return true;
            }
            else 
            {
                return false;
            }
        }

    }

}


 

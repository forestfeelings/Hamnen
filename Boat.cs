using System;
using System.Collections.Generic;

namespace Hamnen
{
    public class Boat
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public int PortSpaceRequired { get; set; }
        public List<int> PortSpaceOccupied { get; set; }
        public int DaysLeftInHarbor { get; set; }
    }

    public class MotorBoat : Boat
    {
        public MotorBoat(string name, string type, int portSpaceRequired, int daysLeftInHarbor)
        {
            Name = name;
            Type = type;
            PortSpaceRequired = portSpaceRequired;
            DaysLeftInHarbor = daysLeftInHarbor;
        }
    }

    public class SailBoat : Boat
    {
        public SailBoat(string name, string type, int portSpaceRequired, int daysLeftInHarbor)
        {
            Name = name;
            Type = type;
            PortSpaceRequired = portSpaceRequired;
            DaysLeftInHarbor = daysLeftInHarbor;
        }
    }

    public class CargoShip : Boat
    {
        public CargoShip(string name, string type, int portSpaceRequired, int daysLeftInHarbor)
        {
            Name = name;
            Type = type;
            PortSpaceRequired = portSpaceRequired;
            DaysLeftInHarbor = daysLeftInHarbor;
        }
    }

}



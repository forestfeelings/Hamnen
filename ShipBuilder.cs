using System;

namespace Hamnen
{
    public class ShipBuilder
    {
        private readonly Random random;
        public ShipBuilder()
        {
            random = new Random();
        }
        public Boat GenerateBoat()
        {
            int boatType = random.Next(1, 4);

            switch (boatType)
            {
                case 1:
                    return CreateMotorBoat();
                case 2:
                    return CreateSailBoat(); ;
                default:
                    return CreateCargoShip();
            }
        }

        private Boat CreateCargoShip()
        {
            CargoShip cargoShip = new CargoShip(
                name: $"L-{RegistrationLetters()}",
                type: "Lastfartyg",
                portSpaceRequired: 4,
                daysLeftInHarbor: 6
                );
            return cargoShip;
        }

        private Boat CreateSailBoat()
        {
            SailBoat sailBoat = new SailBoat(
                name: $"S-{RegistrationLetters()}",
                type: "Segelbåt",
                portSpaceRequired: 2,
                daysLeftInHarbor: 4
                );
            return sailBoat;
        }

        public Boat CreateMotorBoat()
        {
            MotorBoat motorBoat = new MotorBoat(
                name: $"M-{RegistrationLetters()}",
                type: "Motorbåt",
                portSpaceRequired: 1,
                daysLeftInHarbor: 3
                );
            return motorBoat;
        }

        private string RegistrationLetters()
        {
            var letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            var chars = new char[3];

            for (int i = 0; i < chars.Length; i++)
            {
                chars[i] = letters[random.Next(letters.Length)];
            }

            var registrationLetters = new String(chars);

            return registrationLetters;
        }
    }
}
using System;
using Trestlebridge.Interfaces;
using Trestlebridge.Models;
using Trestlebridge.Models.Facilities;
using Trestlebridge.Actions;

namespace Trestlebridge.Actions {
    public class ChooseEquipment {
        public static void CollectInput (Farm farm) {
            Console.WriteLine ("1. Meat processor");
            Console.WriteLine ("2. Egg gatherer");
            Console.WriteLine ("3. Feather harvester");
            Console.WriteLine ("4. Composter");
            Console.WriteLine ("5. Seed harvester");

            Console.WriteLine ();
            Console.WriteLine ("Choose equipment to use");

            Console.Write ("> ");
            string input = Console.ReadLine ();

            switch (Int32.Parse(input))
            {
                case 1:
                    // ChooseMeatProcessor.CollectInput(farm);
                    break;
                case 2:
                    ChooseEggGatherer.CollectInput(farm);
                    break;
                case 3:
                    ChooseFeatherHarvester.CollectInput(farm);
                    break;
                case 4:
                    // ChooseComposter.CollectInput(farm);
                    break;
                case 5:
                     ChooseSeedHarvester.CollectInput(farm);
                    break;
                default:
                    break;
            }
        }
    }
}
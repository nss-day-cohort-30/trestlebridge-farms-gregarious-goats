using System;
using System.Linq;
using Trestlebridge.Interfaces;
using Trestlebridge.Models;
using Trestlebridge.Models.Animals;

namespace Trestlebridge.Actions {
    public class ChooseChickenHouse {
        public static void CollectInput (Farm farm, IHouseDwelling animal) {
            //Console.Clear();
            if (farm.ChickenHouses.Count() == 0) {
                Console.WriteLine("*** Oops! You need to purchase a chicken house first! ***");
                Console.WriteLine("*** Press return key to go back to main menu.");
                Console.ReadLine();
            } else {
                for (int i = 0; i < farm.ChickenHouses.Count; i++)
                {
                    Console.WriteLine ($"{i + 1}. Chicken House ({farm.ChickenHouses[i]._animals.Count} animals)");
                }

                Console.WriteLine ();

                // How can I output the type of animal chosen here?
                Console.WriteLine ($"Place the animal where?");

                Console.Write ("> ");
                int choice = Int32.Parse(Console.ReadLine ());

                farm.ChickenHouses[choice - 1].AddResource(farm, animal);

                /*
                    Couldn't get this to work. Can you?
                    Stretch goal. Only if the app is fully functional.
                */
                // farm.PurchaseResource<IGrazing>(animal, choice);
            }
        }
    }
}
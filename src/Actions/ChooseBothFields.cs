using System;
using System.Collections.Generic;
using System.Linq;
using Trestlebridge.Interfaces;
using Trestlebridge.Models;
using Trestlebridge.Models.Animals;
using Trestlebridge.Models.Plants;

namespace Trestlebridge.Actions {
    public class ChooseBothField {
        public static void CollectInput (Farm farm, SunFlower seed) {
            //Console.Clear();
            if (farm.PlowedFields.Count() == 0 && farm.NaturalFields.Count() == 0) {
                Console.WriteLine("*** Oops! You need to purchase a natural field or plowed field first! ***");
                Console.WriteLine("*** Press return key to go back to main menu.");
                Console.ReadLine();
            } else {
                for (int i = 0; i < farm.NaturalFields.Count; i++)
                {
                    Console.WriteLine ($"{i + 1}. Natural Field");
                }
                for (int i = 0; i < farm.PlowedFields.Count; i++)
                {
                    Console.WriteLine ($"{farm.NaturalFields.Count+ i + 1}. Plowed Field");
                }

                Console.WriteLine ();

                // How can I output the type of animal chosen here?
                Console.WriteLine ($"Where would you like to plant the Sunflowers?");

                Console.Write ("> ");

                int choice = Int32.Parse(Console.ReadLine ());
                choice--;
                if(choice < farm.NaturalFields.Count)
                    farm.NaturalFields[choice].AddResource(farm, (INaturalFieldDwelling)seed);
                else
                    farm.PlowedFields[choice-farm.NaturalFields.Count].AddResource(farm, (IPlowedFieldDwelling)seed);

                /*
                    Couldn't get this to work. Can you?
                    Stretch goal. Only if the app is fully functional.
                */
                // farm.PurchaseResource<IGrazing>(animal, choice);
            }
        }
        public static void CollectInput (Farm farm, List<SunFlower> seeds) {
            //Console.Clear();
            if (farm.PlowedFields.Count() == 0 && farm.NaturalFields.Count() == 0) {
                Console.WriteLine("*** Oops! You need to purchase a natural field or plowed field first! ***");
                Console.WriteLine("*** Press return key to go back to main menu.");
                Console.ReadLine();
            } else {
                for (int i = 0; i < farm.NaturalFields.Count; i++)
                {
                    Console.WriteLine ($"{i + 1}. Natural Field");
                }
                for (int i = 0; i < farm.PlowedFields.Count; i++)
                {
                    Console.WriteLine ($"{farm.NaturalFields.Count+ i + 1}. Plowed Field");
                }

                Console.WriteLine ();

                // How can I output the type of animal chosen here?
                Console.WriteLine ($"Where would you like to plant the Sunflowers?");

                Console.Write ("> ");

                int choice = Int32.Parse(Console.ReadLine ());
                choice--;
                if(choice < farm.NaturalFields.Count)
                {
                    List<INaturalFieldDwelling> seed = seeds.Cast<INaturalFieldDwelling>().ToList();
                    farm.NaturalFields[choice].AddResource( seed);
                }
                else
                {
                    List<IPlowedFieldDwelling> seed = seeds.Cast<IPlowedFieldDwelling>().ToList();
                    farm.PlowedFields[choice-farm.NaturalFields.Count].AddResource(seed);
                }

                /*
                    Couldn't get this to work. Can you?
                    Stretch goal. Only if the app is fully functional.
                */
                // farm.PurchaseResource<IGrazing>(animal, choice);
            }
        }
    }
}
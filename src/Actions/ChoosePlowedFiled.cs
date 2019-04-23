using System;
using System.Collections.Generic;
using System.Linq;
using Trestlebridge.Interfaces;
using Trestlebridge.Models;
using Trestlebridge.Models.Animals;

namespace Trestlebridge.Actions {
    public class ChoosePlowedField {
        public static void CollectInput (Farm farm, IPlowedFieldDwelling seed) {
            //Console.Clear();
            if (farm.PlowedFields.Count() == 0) {
                Console.WriteLine("*** Oops! You need to purchase a plowed field first! ***");
                Console.WriteLine("*** Press return key to go back to main menu.");
                Console.ReadLine();
            } else {
                int counter = 0;
                for (int i = 0; i < farm.PlowedFields.Count; i++)
                {      // Only show facilities that are not full
                    if (farm.PlowedFields[i]._plants.Count != farm.PlowedFields[i].Capacity) {
                        Console.WriteLine ($"{i + 1}. Plowed Field ({farm.PlowedFields[i]._plants.Count}/{farm.PlowedFields[i].Capacity} rows of plants)");
                    } else {
                        counter++;
                } // If all options are full, tell user to buy another one
                    if (counter == farm.PlowedFields.Count){
                        Console.WriteLine("*** Oops! All your plowed fields are full, you need another one! ***");
                        Console.WriteLine("*** Press return key to go back to main menu.");
                        Console.ReadLine();
                    } else {
                        Console.WriteLine ();

                        // How can I output the type of animal chosen here?
                        Console.WriteLine ($"Where would you like to plant the {seed.Type}?");

                        Console.Write ("> ");
                        int choice = Int32.Parse(Console.ReadLine ());

                        farm.PlowedFields[choice-1].AddResource(farm, seed);
                    }

                /*
                    Couldn't get this to work. Can you?
                    Stretch goal. Only if the app is fully functional.
                */
                // farm.PurchaseResource<IGrazing>(animal, choice);
            }
        }
        }

        public static void CollectInput(Farm farm, List<IPlowedFieldDwelling> seeds)
        {

            for (int i = 0; i < farm.PlowedFields.Count; i++)
            {
                Console.WriteLine ($"{i + 1}. Plowed Field ({farm.PlowedFields[i]._plants.Count}/{farm.PlowedFields[i].Capacity} rows of plants)");
            }

            Console.WriteLine ();

            // How can I output the type of animal chosen here?
            Console.WriteLine ($"Where would you like to plant the {seeds[0].Type}?");

            Console.Write ("> ");
            int choice = Int32.Parse(Console.ReadLine ());

            farm.PlowedFields[choice-1].AddResource(seeds);

            /*
                Couldn't get this to work. Can you?
                Stretch goal. Only if the app is fully functional.
             */
            // farm.PurchaseResource<IGrazing>(animal, choice);

         }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using Trestlebridge.Interfaces;
using Trestlebridge.Models;
using Trestlebridge.Models.Animals;

namespace Trestlebridge.Actions {
    public class ChooseNaturalField {
        public static void CollectInput (Farm farm, INaturalFieldDwelling seed) {
            //Console.Clear();
            if (farm.NaturalFields.Count() == 0) {
                Console.WriteLine("*** Oops! You need to purchase a natural field first! ***");
                Console.WriteLine("*** Press return key to go back to main menu.");
                Console.ReadLine();
            } else {
                int counter = 0;
                for (int i = 0; i < farm.NaturalFields.Count; i++)
                {
                    // Only show facilities that are not full
                    if (farm.NaturalFields[i]._plants.Count != farm.NaturalFields[i].Capacity) {
                        Console.WriteLine ($"{i + 1}. Natural Field ({farm.NaturalFields[i]._plants.Count}/{farm.NaturalFields[i].Capacity} rows of plants)");
                    } else {
                        counter++;
                    }
                } // If all options are full, tell user to buy another one
                    if (counter == farm.NaturalFields.Count){
                        Console.WriteLine("*** Oops! All your natural fields are full, you need another one! ***");
                        Console.WriteLine("*** Press return key to go back to main menu.");
                        Console.ReadLine();
                    } else {
                    Console.WriteLine ();

                    // How can I output the type of animal chosen here?
                    Console.WriteLine ($"Where would you like to plant the {seed.Type}?");

                    Console.Write ("> ");
                    int choice = Int32.Parse(Console.ReadLine ());

                    farm.NaturalFields[choice-1].AddResource(farm, seed);
                    }
                /*
                    Couldn't get this to work. Can you?
                    Stretch goal. Only if the app is fully functional.
                */
                // farm.PurchaseResource<IGrazing>(animal, choice);
            }
        }
        public static void CollectInput (Farm farm, List<INaturalFieldDwelling> seeds) {
            //Console.Clear();
            if (farm.NaturalFields.Count() == 0) {
                Console.WriteLine("*** Oops! You need to purchase a natural field first! ***");
                Console.WriteLine("*** Press return key to go back to main menu.");
                Console.ReadLine();
            } else {
                for (int i = 0; i < farm.NaturalFields.Count; i++)
                {
                    Console.WriteLine ($"{i + 1}. Natural Field ({farm.NaturalFields[i]._plants.Count}/{farm.NaturalFields[i].Capacity} rows of plants)");
                }

                Console.WriteLine ();

                // How can I output the type of animal chosen here?
                Console.WriteLine ($"Where would you like to plant the {seeds[0].Type}?");

                Console.Write ("> ");
                int choice = Int32.Parse(Console.ReadLine ());

                farm.NaturalFields[choice-1].AddResource(seeds);

                /*
                    Couldn't get this to work. Can you?
                    Stretch goal. Only if the app is fully functional.
                */
                // farm.PurchaseResource<IGrazing>(animal, choice);
            }
        }
    }
}
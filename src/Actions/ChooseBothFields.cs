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
            Console.Clear();
            if (farm.PlowedFields.Count() == 0 && farm.NaturalFields.Count() == 0) {
                Console.WriteLine("*** Oops! You need to purchase a natural field or plowed field first! ***");
                Console.WriteLine("*** Press return key to go back to main menu.");
                Console.ReadLine();
            } else {
                int counter = 0;
                for (int i = 0; i < farm.NaturalFields.Count; i++)
                {// Only show facilities that are not full
                    if (farm.NaturalFields[i]._plants.Count != farm.NaturalFields[i].Capacity) {
                        Console.WriteLine ($"{i + 1}. Natural Field ({farm.NaturalFields[i]._plants.Count}/{farm.NaturalFields[i].Capacity} rows of plants)");
                    } else {
                        counter++;
                    }
                }
                for (int i = 0; i < farm.PlowedFields.Count; i++)
                {// Only show facilities that are not full
                    if (farm.PlowedFields[i]._plants.Count != farm.PlowedFields[i].Capacity) {
                        Console.WriteLine ($"{farm.NaturalFields.Count+ i + 1}. Plowed Field ({farm.PlowedFields[i]._plants.Count}/{farm.PlowedFields[i].Capacity} rows of plants)");
                    } else {
                        counter++;
                }// If all options are full, tell user to buy another one
                    if (counter == (farm.PlowedFields.Count + farm.NaturalFields.Count)){
                        Console.WriteLine("*** Oops! All your plowed and natural fields are full, you need another one! ***");
                        Console.WriteLine("*** Press return key to go back to main menu.");
                        Console.ReadLine();
                    } else {

                        Console.WriteLine ();

                        // How can I output the type of animal chosen here?
                        Console.WriteLine ($"Where would you like to plant the {seed.Type}?");

                        Console.Write ("> ");

                        int choice = Int32.Parse(Console.ReadLine ());
                        choice--;
                        if(choice < farm.NaturalFields.Count)
                            farm.NaturalFields[choice].AddResource(farm, (INaturalFieldDwelling)seed);
                        else
                            farm.PlowedFields[choice-farm.NaturalFields.Count].AddResource(farm, (IPlowedFieldDwelling)seed);
                    }
                }

                /*
                    Couldn't get this to work. Can you?
                    Stretch goal. Only if the app is fully functional.
                */
                // farm.PurchaseResource<IGrazing>(animal, choice);
            }
        }
        public static void CollectInput (Farm farm, List<SunFlower> seeds) {
            Console.Clear();
            if (farm.PlowedFields.Count() == 0 && farm.NaturalFields.Count() == 0) {
                Console.WriteLine("*** Oops! You need to purchase a natural field or plowed field first! ***");
                Console.WriteLine("*** Press return key to go back to main menu.");
                Console.ReadLine();
            } else {
                for (int i = 0; i < farm.NaturalFields.Count; i++)
                {
                    Console.WriteLine ($"{i + 1}. Natural Field ({farm.NaturalFields[i]._plants.Count} rows of plants)");
                }
                for (int i = 0; i < farm.PlowedFields.Count; i++)
                {
                    Console.WriteLine ($"{farm.NaturalFields.Count+ i + 1}. Plowed Field ({farm.PlowedFields[i]._plants.Count} rows of plants)");
                }

                Console.WriteLine ();

                // How can I output the type of animal chosen here?
                Console.WriteLine ($"Where would you like to plant {seeds.Count} {seeds[0].Type} seeds?");

                Console.Write ("> ");

                int choice = Int32.Parse(Console.ReadLine ());
                choice--;
                if(choice < farm.NaturalFields.Count)
                {
                    List<INaturalFieldDwelling> seed = seeds.Cast<INaturalFieldDwelling>().ToList();
                    farm.NaturalFields[choice].AddResource(farm, seed);
                }
                else
                {
                    List<IPlowedFieldDwelling> seed = seeds.Cast<IPlowedFieldDwelling>().ToList();
                    farm.PlowedFields[choice-farm.NaturalFields.Count].AddResource(farm, seed);
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
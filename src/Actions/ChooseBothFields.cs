using System;
using System.Collections.Generic;
using System.Linq;
using Trestlebridge.Interfaces;
using Trestlebridge.Models;
using Trestlebridge.Models.Animals;
using Trestlebridge.Models.Plants;

namespace Trestlebridge.Actions {
    public class ChooseBothField {
        public static void CollectInput (Farm farm, IResource seed) {
            //Console.Clear();
            if (farm.PlowedFields.Count() == 0 && farm.NaturalFields.Count() == 0) {
                Console.WriteLine("*** Oops! You need to purchase a natural field or plowed field first! ***");
                Console.WriteLine("*** Press return key to go back to main menu.");
                Console.ReadLine();
            } else {
                try
                {
                    int counter = 0;
                    for (int i = 0; i < farm.NaturalFields.Count; i++)
                    {// Only show facilities that are not full
                        if (farm.NaturalFields[i]._plants.Count != farm.NaturalFields[i].Capacity) {
                            var groupedPlants = farm.NaturalFields[i]._plants.GroupBy(
                                currentPlant => currentPlant.Type
                                );
                            var plantString = "";
                            foreach (var currentPlantGroup in groupedPlants)
                            {
                                plantString += currentPlantGroup.Count() + " " + currentPlantGroup.Key + ",";
                            };
                            Console.WriteLine($"{i + 1}. Natural Field ({plantString})");
                        } else {
                            counter++;
                        }
                    }
                    for (int i = 0; i < farm.PlowedFields.Count; i++)
                    {// Only show facilities that are not full
                        if (farm.PlowedFields[i]._plants.Count != farm.PlowedFields[i].Capacity) {
                            var groupedPlants = farm.PlowedFields[i]._plants.GroupBy(
                                currentPlant => currentPlant.Type
                                );
                            var plantString = "";
                            foreach (var currentPlantGroup in groupedPlants)
                            {
                                plantString += currentPlantGroup.Count() + " " + currentPlantGroup.Key + ",";
                            };
                            Console.WriteLine($"{farm.NaturalFields.Count + i + 1}. Plowed Field ({plantString})");
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
                catch (FormatException){}
            }
        }
        public static void CollectInput (Farm farm, List<IResource> seeds) {
            //Console.Clear();
            if (farm.PlowedFields.Count() == 0 && farm.NaturalFields.Count() == 0) {
                Console.WriteLine("*** Oops! You need to purchase a natural field or plowed field first! ***");
                Console.WriteLine("*** Press return key to go back to main menu.");
                Console.ReadLine();
            } else {
                try
                {
                    for (int i = 0; i < farm.NaturalFields.Count; i++)
                    {
                        var groupedPlants = farm.NaturalFields[i]._plants.GroupBy(
                            currentPlant => currentPlant.Type
                            );
                        var plantString = "";
                        foreach (var currentPlantGroup in groupedPlants)
                        {
                            plantString += currentPlantGroup.Count() + " " + currentPlantGroup.Key + ",";
                        };
                        Console.WriteLine($"{i + 1}. Natural Field ({plantString})");
                    }
                    for (int i = 0; i < farm.PlowedFields.Count; i++)
                    {
                        var groupedPlants = farm.PlowedFields[i]._plants.GroupBy(
                            currentPlant => currentPlant.Type
                            );
                        var plantString = "";
                        foreach (var currentPlantGroup in groupedPlants)
                        {
                            plantString += currentPlantGroup.Count() + " " + currentPlantGroup.Key + ",";
                        };
                        Console.WriteLine($"{farm.NaturalFields.Count + i + 1}. Plowed Field ({plantString})");
                    }

                    Console.WriteLine ();

                    // How can I output the type of animal chosen here?
                    Console.WriteLine ($"Where would you like to plant {seeds.Count} {seeds[0].Type} seeds?");

                    Console.Write ("> ");

                    int choice = Int32.Parse(Console.ReadLine ());
                    choice--;
                    if(choice < farm.NaturalFields.Count)
                    {
                        List<IResource> seed = seeds.Cast<IResource>().ToList();
                        farm.NaturalFields[choice].AddResource(farm, seed);
                    }
                    else
                    {
                        List<IResource> seed = seeds.Cast<IResource>().ToList();
                        farm.PlowedFields[choice-farm.NaturalFields.Count].AddResource(farm, seed);

                    }
                }
                catch (FormatException){}
                /*
                    Couldn't get this to work. Can you?
                    Stretch goal. Only if the app is fully functional.
                */
                // farm.PurchaseResource<IGrazing>(animal, choice);
            }
        }
    }
}
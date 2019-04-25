using System;
using System.Linq;
using Trestlebridge.Interfaces;
using Trestlebridge.Models;
using Trestlebridge.Models.Animals;
using Trestlebridge.Models.BaseClasses;

namespace Trestlebridge.Actions {
    public class ChooseSeedHarvester{
        public static void CollectInput (Farm farm) {
            // Console.Clear();
            if (farm.NaturalFields.Count == 0 && farm.PlowedFields.Count == 0) {
                Console.WriteLine("*** Oops! You don't have any meat-producing facilities! ***");
                Console.WriteLine("*** Press return key to go back to main menu.");
                Console.ReadLine();
            }
            else
            {
                try
                {   // Show available facilities and plant counts
                    // for (int i = 0; i < farm.NaturalFields.Count; i++)
                    // {
                    //     var groupedPlants = farm.NaturalFields[i]._plants.GroupBy(
                    //         currentPlant => currentPlant.Type
                    //         );
                    //     var plantsString = "";
                    //     foreach (var currentPlantGroup in groupedPlants)
                    //     {
                    //         plantsString += currentPlantGroup.Count() + " " + currentPlantGroup.Key + ",";
                    //     };
                    //     Console.WriteLine($"{i + 1}. Natural Field ({plantsString})");
                    // }
                    // for (int i = 0; i < farm.NaturalFields.Count; i++)
                    // {
                    //     Console.WriteLine($"{farm.NaturalFields.Count + i + 1}. Natural Field ({farm.NaturalFields[i]._plants.Count} plants)");
                    // }
                        Console.WriteLine ();

                        Console.WriteLine ($"Which field you want to harvest?");

                        Console.Write ("> ");

                        int input = Int32.Parse(Console.ReadLine ());

                                var groupedPlants = farm.NaturalFields[0]._plants.GroupBy(
                                    currentPlant => currentPlant.Type
                                    ).Select(x => x.ToList());
                                var i = 1;
                                Console.WriteLine(groupedPlants);
                                foreach (var currentPlantGroup in groupedPlants)
                                {
                                    Console.WriteLine($"{i}. {currentPlantGroup.Count() + " " + currentPlantGroup}");
                                    i++;
                                };
                                Console.WriteLine("Which plant should be Harvested?");
                                int field = Int32.Parse(Console.ReadLine());
                                //groupedPlants[field - 1].Type
                                Console.WriteLine();

                                Console.WriteLine("How many plants should be Harvested?");
                                int qtyPlants = Int32.Parse(Console.ReadLine());

                                Console.WriteLine("Ready to Process? (y/n) ");
                                if (Console.ReadLine() == "y")
                                {

                                }
                }
                catch (FormatException){}
            }
        }
    }
}
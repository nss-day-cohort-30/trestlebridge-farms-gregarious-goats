using System;
using System.Collections.Generic;
using System.Linq;
using Trestlebridge.Interfaces;
using Trestlebridge.Models;
using Trestlebridge.Models.Animals;
using Trestlebridge.Models.BaseClasses;
using Trestlebridge.Equipments;
using Trestlebridge.Models.Plants;

namespace Trestlebridge.Actions {
        public class ChooseSeedHarvester {
            public static void CollectInput (Farm farm) {
                    // Console.Clear();
                    if (farm.NaturalFields.Count == 0 && farm.PlowedFields.Count == 0) {
                        Console.WriteLine ("*** Oops! You don't have any seeds Harvesting facilities! ***");
                        Console.WriteLine ("*** Press return key to go back to main menu.");
                        Console.ReadLine ();
                    } else {
                        try { // Show available facilities and plant counts
                            SeedHarvester Equipment = new SeedHarvester();
                            for (int p = 0; p < farm.NaturalFields.Count; p++) {
                                var groupPlants = farm.NaturalFields[p].Resources.GroupBy (
                                    currentPlant => currentPlant.Type
                                );
                                var plantsString = "";
                                foreach (var currentPlantGroup in groupPlants) {
                                    plantsString += currentPlantGroup.Count () + " " + currentPlantGroup.Key + ",";
                                };
                                Console.WriteLine ($"{p + 1}. Natural Field ({plantsString})");
                            }
                            Console.WriteLine ();

                            Console.WriteLine ($"Which field you want to harvest?");

                            int field = Int32.Parse (Console.ReadLine ());

                            //if (field <= farm.NaturalFields.Count) {
                            Console.WriteLine ("The following plants in that field:");
                            // var groupedPlants = farm.NaturalFields[field - 1].Resources.GroupBy (
                            //     currentPlant => currentPlant.Type
                            // );
                            var groupedPlants =
                                from plant in farm.NaturalFields[field - 1].Resources
                            group plant by plant.Type into newGroup
                            select newGroup;

                            int j = 1;
                            foreach (var currentPlantGroup in groupedPlants) {
                                Console.WriteLine ($"{j}. {currentPlantGroup.Count() + " " + currentPlantGroup.Key}");
                                j++;
                            };

                            Console.WriteLine ();
                            Console.WriteLine ("Which Plants should be harvested?");
                            Console.Write ("> ");

                            int inputType= Int32.Parse (Console.ReadLine ());
                            Console.WriteLine ();
                            Console.WriteLine ("How many Plants you want be harvested?");
                            Console.Write ("> ");

                            int qty = Int32.Parse (Console.ReadLine ());
                            j = 1;
                            List<Plant> selectedType = new List<Plant> ();
                            foreach (var currentPlantGroup in groupedPlants) {
                                if(j == inputType)
                                    foreach (var selectedPlant in currentPlantGroup)
                                    {
                                        selectedType.Add((Plant)selectedPlant);
                                    }
                                j++;
                            };
                            Console.WriteLine(selectedType[0].Type);
                            if(selectedType[0].Type == "SunFlower") {
                                SunFlower sunny = new SunFlower();
                                if(qty == 1)
                                {
                                    farm.NaturalFields[field - 1].RemoveResource(farm, (IResource)selectedType[0]);
                                    Console.WriteLine($"seeds : {sunny.Process(Equipment)}");
                                }
                            }


                            // if (qty >= 1) {
                            //     farm.NaturalFields[field].RemoveResource (farm, selectedType);
                            // }

                            // } else {
                            //     Console.WriteLine ("The following animals are in the chicken house:");
                            //     var groupedAnimals = farm.ChickenHouses[choice - farm.GrazingFields.Count - 1].Resources.GroupBy (
                            //         currentAnimal => currentAnimal.Type
                            //     );
                            //     var i = 1;
                            //     foreach (var currentAnimalGroup in groupedAnimals) {
                            //         Console.WriteLine ($"{i}. {currentAnimalGroup.Count() + " " + currentAnimalGroup.Key}");
                            //         i++;
                            //     };
                            //     Console.WriteLine ();
                            //     Console.WriteLine ("Which resource should be processed?");
                            //     Console.Write ("> ");

                            //     int input = Int32.Parse (Console.ReadLine ());
                            // }
                        } catch (FormatException) { }

                    }
            }
        }
}

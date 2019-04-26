using System;
using System.Collections.Generic;
using System.Linq;
using Trestlebridge.Equipments;
using Trestlebridge.Interfaces;
using Trestlebridge.Models;
using Trestlebridge.Models.Animals;
using Trestlebridge.Models.BaseClasses;
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
                    SeedHarvester Equipment = new SeedHarvester ();
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
                    for (int p = 0; p < farm.PlowedFields.Count; p++) {
                        var groupPlants = farm.PlowedFields[p].Resources.GroupBy (
                            currentPlant => currentPlant.Type
                        );
                        var plantsString = "";
                        foreach (var currentPlantGroup in groupPlants) {
                            plantsString += currentPlantGroup.Count () + " " + currentPlantGroup.Key + ",";
                        };
                        Console.WriteLine ($"{farm.NaturalFields.Count + p + 1}. Plowed Field ({plantsString})");
                    }
                    Console.WriteLine ();

                    Console.WriteLine ($"Which field you want to harvest?");

                    int field = Int32.Parse (Console.ReadLine ());
                    IEnumerable<IGrouping<string, IResource>> groupedPlants;
                    if (field <= farm.NaturalFields.Count) {
                        Console.WriteLine ("The following plants in that field:");
                        groupedPlants =
                            from plant in farm.NaturalFields[field - 1].Resources
                        where plant.Type == "Sesame" || plant.Type == "SunFlower"
                        group plant by plant.Type into newGroup
                        select newGroup;
                    } else {
                        Console.WriteLine ("The following plants in that field:");
                        groupedPlants =
                            from plant in farm.PlowedFields[field - farm.NaturalFields.Count - 1].Resources
                        where plant.Type == "Sesame" || plant.Type == "SunFlower"
                        group plant by plant.Type into newGroup
                        select newGroup;
                    }
                    if (groupedPlants.Count () == 0) {
                        Console.WriteLine ("There are no plants for harvesting...");
                        Console.ReadLine ();
                    } else {

                        int j = 1;
                        foreach (var currentPlantGroup in groupedPlants) {
                            Console.WriteLine ($"{j}. {currentPlantGroup.Count() + " " + currentPlantGroup.Key}");
                            j++;
                        };

                        Console.WriteLine ();
                        Console.WriteLine ("Which Plants should be harvested?");
                        Console.Write ("> ");

                        int inputType = Int32.Parse (Console.ReadLine ());
                        Console.WriteLine ();
                        Console.WriteLine ("How many Plants you want be harvested?");
                        Console.Write ("> ");

                        int qty = Int32.Parse (Console.ReadLine ());
                        j = 1;
                        List<IResource> selectedType = new List<IResource> ();
                        foreach (var currentPlantGroup in groupedPlants) {
                            if (j == inputType)
                                foreach (var selectedPlant in currentPlantGroup) {
                                    if (selectedType.Count < qty)
                                        selectedType.Add (selectedPlant);
                                    else
                                        break;
                                }
                            j++;
                        };

                        Console.WriteLine (selectedType.Count);
                        if (field <= farm.NaturalFields.Count) {
                            SunFlower sunny = new SunFlower ();
                            if (qty == 1) {
                                farm.NaturalFields[field - 1].RemoveResource (farm, selectedType[0]);
                                Console.WriteLine ($"Total seeds Harvested: {sunny.Process(Equipment)}");
                            } else {
                                farm.NaturalFields[field - 1].RemoveResource (farm, selectedType);
                                Console.WriteLine ($"Total seeds Harvested: {sunny.Process(Equipment)}");
                            }
                        } else {
                            if (selectedType[0].Type == "SunFlower") {
                                SunFlower sunny = new SunFlower ();
                                if (qty == 1) {
                                    farm.PlowedFields[field - farm.NaturalFields.Count - 1].RemoveResource (farm, selectedType[0]);
                                    Console.WriteLine ($"Total seeds Harvested: {sunny.Process(Equipment)}");
                                }
                            } else {
                                Sesame sesamy = new Sesame ();
                                if (qty == 1) {
                                    farm.PlowedFields[field - farm.NaturalFields.Count - 1].RemoveResource (farm, selectedType[0]);
                                    Console.WriteLine ($"Total seeds Harvested: {sesamy.Process(Equipment)}");
                                }

                            }
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
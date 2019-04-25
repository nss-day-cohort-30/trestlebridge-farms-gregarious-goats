using System;
using System.Linq;
using Trestlebridge.Interfaces;
using Trestlebridge.Models;
using Trestlebridge.Models.Animals;
using Trestlebridge.Models.BaseClasses;

namespace Trestlebridge.Actions {
    public class ChooseMeatProcessor {
        public static void CollectInput (Farm farm) {
            // Console.Clear();
            if (farm.GrazingFields.Count == 0 && farm.ChickenHouses.Count == 0) {
                Console.WriteLine("*** Oops! You don't have any meat-producing facilities! ***");
                Console.WriteLine("*** Press return key to go back to main menu.");
                Console.ReadLine();
            } else {
                try
                {   // Show available facilities and animal counts
                    for (int i = 0; i < farm.GrazingFields.Count; i++)
                    {
                        var groupedAnimals = farm.GrazingFields[i]._animals.GroupBy(
                            currentAnimal => currentAnimal.Type
                            );
                        var animalsString = "";
                        foreach (var currentAnimalGroup in groupedAnimals)
                        {
                            animalsString += currentAnimalGroup.Count() + " " + currentAnimalGroup.Key + ",";
                        };
                        Console.WriteLine($"{i + 1}. Grazing Field ({animalsString})");
                    }
                    for (int i = 0; i < farm.ChickenHouses.Count; i++)
                    {
                        Console.WriteLine($"{farm.GrazingFields.Count + i + 1}. Chicken House ({farm.ChickenHouses[i]._animals.Count} chickens)");
                    }
                        Console.WriteLine ();
                        Console.WriteLine ($"Which facility has the animals you want to process?");
                        Console.Write ("> ");

                        int choice = Int32.Parse(Console.ReadLine());

                        if (choice <= farm.GrazingFields.Count) {
                            Console.WriteLine("The following animals are in the grazing field:");
                            var groupedAnimals = farm.GrazingFields[choice - 1]._animals.GroupBy(
                                    currentAnimal => currentAnimal.Type
                                    );
                                var i = 1;
                                foreach (var currentAnimalGroup in groupedAnimals)
                                {
                                    Console.WriteLine($"{i}. {currentAnimalGroup.Count() + " " + currentAnimalGroup.Key}");
                                    i++;
                                };

                                Console.WriteLine ();
                                Console.WriteLine("Which resource should be processed?");
                                Console.Write ("> ");

                                int input = Int32.Parse(Console.ReadLine ());

                        } else {
                            Console.WriteLine("The following animals are in the chicken house:");
                            var groupedAnimals = farm.ChickenHouses[choice - farm.GrazingFields.Count - 1]._animals.GroupBy(
                                    currentAnimal => currentAnimal.Type
                                    );
                                var i = 1;
                                foreach (var currentAnimalGroup in groupedAnimals)
                                {
                                    Console.WriteLine($"{i}. {currentAnimalGroup.Count() + " " + currentAnimalGroup.Key}");
                                    i++;
                                };
                                Console.WriteLine ();
                                Console.WriteLine("Which resource should be processed?");
                                Console.Write ("> ");

                                int input = Int32.Parse(Console.ReadLine ());
                        }
                    }
                catch (FormatException){}
            }
        }
    }
}
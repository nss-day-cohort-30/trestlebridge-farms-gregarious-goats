using System;
using System.Collections.Generic;
using System.Linq;
using Trestlebridge.Interfaces;
using Trestlebridge.Models;
using Trestlebridge.Models.Animals;
using Trestlebridge.Models.BaseClasses;

namespace Trestlebridge.Actions
{
    public class ChooseEggGatherer
    {
        public static void CollectInput(Farm farm)
        {
            List<Facility> fieldsWithOstrichs = farm.GrazingFields.Where(gField => gField.Resources.Where(resource => resource is IEggProducing).Any()).ToList();

            if (farm.ChickenHouses.Count == 0
            && farm.DuckHouses.Count == 0
            && fieldsWithOstrichs.Count == 0)
            {
                Console.WriteLine("*** Oops! You don't have any meat-producing facilities! ***");
                Console.WriteLine("*** Press return key to go back to main menu.");
                Console.ReadLine();
            }
            else
            {
                // Create list of facilities that can have eggs:
                List<Facility> FacilitiesThatHaveEggAnimals = new List<Facility>();
                foreach (Facility facility in fieldsWithOstrichs)
                {
                    FacilitiesThatHaveEggAnimals.Add(facility);
                }
                foreach (Facility facility in farm.ChickenHouses)
                {
                    FacilitiesThatHaveEggAnimals.Add(facility);
                }
                foreach (Facility facility in farm.DuckHouses)
                {
                    FacilitiesThatHaveEggAnimals.Add(facility);
                }

                // Show users options for facilities
                for (int i = 0; i < FacilitiesThatHaveEggAnimals.Count; i++)
                {
                    var groupedAnimals = FacilitiesThatHaveEggAnimals[i].Resources.GroupBy(
                        currentAnimal => currentAnimal.Type
                    );

                    var animalsString = "";
                    foreach (var group in groupedAnimals)
                    {
                        animalsString += group.Count() + " " + group.Key + ", ";
                    };


                    Console.WriteLine($"{i + 1}: {FacilitiesThatHaveEggAnimals[i].GetType().ToString().Split(".")[FacilitiesThatHaveEggAnimals[i].GetType().ToString().Split(".").Count() - 1]} -- {animalsString} ");
                }




                Console.WriteLine();
                Console.WriteLine($"Which facility has the animals you want to process?");
                Console.Write("> ");

                int choice = Int32.Parse(Console.ReadLine());

                //         if (choice <= farm.GrazingFields.Count)
                //         {
                //             Console.WriteLine("The following animals are in the grazing field:");
                //             var groupedAnimals = farm.GrazingFields[choice - 1].Resources.GroupBy(
                //                     currentAnimal => currentAnimal.Type
                //                     );
                //             var i = 1;
                //             foreach (var currentAnimalGroup in groupedAnimals)
                //             {
                //                 Console.WriteLine($"{i}. {currentAnimalGroup.Count() + " " + currentAnimalGroup.Key}");
                //                 i++;
                //             };

                //             Console.WriteLine();
                //             Console.WriteLine("Which resource should be processed?");
                //             Console.Write("> ");

                //             int input = Int32.Parse(Console.ReadLine());

                //         }
                //         else
                //         {
                //             Console.WriteLine("The following animals are in the chicken house:");
                //             var groupedAnimals = farm.ChickenHouses[choice - farm.GrazingFields.Count - 1].Resources.GroupBy(
                //                     currentAnimal => currentAnimal.Type
                //                     );
                //             var i = 1;
                //             foreach (var currentAnimalGroup in groupedAnimals)
                //             {
                //                 Console.WriteLine($"{i}. {currentAnimalGroup.Count() + " " + currentAnimalGroup.Key}");
                //                 i++;
                //             };
                //             Console.WriteLine();
                //             Console.WriteLine("Which resource should be processed?");
                //             Console.Write("> ");

                //             int input = Int32.Parse(Console.ReadLine());
                //         }
                //     }
                //     catch (FormatException) { }
            }
        }
    }
}
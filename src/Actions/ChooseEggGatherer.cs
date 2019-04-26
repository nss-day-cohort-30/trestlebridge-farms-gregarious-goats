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

                int facilityChoiceNum = Int32.Parse(Console.ReadLine()) - 1;
                if (facilityChoiceNum <= FacilitiesThatHaveEggAnimals.Count)
                {
                    var chosenFacility = FacilitiesThatHaveEggAnimals[facilityChoiceNum];
                    var chosenFacilityId = chosenFacility.ShortId;
                    var chosenFacilityAnimalTypes = chosenFacility.Resources
                    .GroupBy(animal => animal.Type)
                    .Select(grp => grp.ToList())
                    .ToList();
                    Console.WriteLine("The following resource types are in that facility:");
                    for (int i = 0; i < chosenFacilityAnimalTypes.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}: {chosenFacilityAnimalTypes[i].Count} x {chosenFacilityAnimalTypes[i][0].Type}");
                    }

                    Console.WriteLine();
                    Console.WriteLine("Which resource would you like to COMPRESS INTO EGGS?");
                    Console.Write("> ");


                    int animalTypeChoiceNum = Int32.Parse(Console.ReadLine()) - 1;

                    string chosenAnimalType = chosenFacilityAnimalTypes[animalTypeChoiceNum][0].Type;
                    dynamic resourceClassTemplate = Activator.CreateInstance(chosenFacilityAnimalTypes[animalTypeChoiceNum][0].GetType());
                    double eggConversionMultiplier = ((IEggProducing)chosenFacilityAnimalTypes[animalTypeChoiceNum][0])._eggsProduced;

                    if (animalTypeChoiceNum <= chosenFacilityAnimalTypes.Count)
                    {
                        Console.WriteLine($"How many of this type of resource would you like to COMPRESS INTO EGGS?");
                        Console.Write("> ");

                        int numResourcesToProcessNum = Int32.Parse(Console.ReadLine());

                        if (numResourcesToProcessNum <= chosenFacilityAnimalTypes[animalTypeChoiceNum].Count)
                        {
                            int EggsReturned = numResourcesToProcessNum * Convert.ToInt32(eggConversionMultiplier);

                            Console.WriteLine($"Are you sure you want to process these into {EggsReturned} eggs? (y or n)");
                            Console.WriteLine("> ");

                            string yesOrNo = Console.ReadLine();
                            if (yesOrNo == "y")
                            {
                                Console.WriteLine($"You did what you had to do. You have compressed {numResourcesToProcessNum} {chosenAnimalType} into {EggsReturned} eggs...");

                                try
                                {
                                    for (var i = 0; i <= numResourcesToProcessNum - 1; i++)
                                    {
                                        farm.GrazingFields.Single(field => field.ShortId == chosenFacilityId).Resources
                                        .RemoveAt(farm.GrazingFields.Single(field => field.ShortId == chosenFacilityId).Resources
                                        .FindIndex(animal => animal.Type == resourceClassTemplate.Type));
                                    }

                                }
                                catch
                                {
                                }
                                try
                                {
                                    for (var i = 0; i <= numResourcesToProcessNum - 1; i++)
                                    {
                                        farm.PlowedFields.Single(field => field.ShortId == chosenFacilityId).Resources
                                        .RemoveAt(farm.PlowedFields.Single(field => field.ShortId == chosenFacilityId).Resources
                                        .FindIndex(animal => animal.Type == resourceClassTemplate.Type));
                                    }
                                }
                                catch
                                {

                                }
                                try
                                {
                                    for (var i = 0; i <= numResourcesToProcessNum - 1; i++)
                                    {
                                        farm.NaturalFields.Single(field => field.ShortId == chosenFacilityId).Resources
                                        .RemoveAt(farm.NaturalFields.Single(field => field.ShortId == chosenFacilityId).Resources
                                        .FindIndex(animal => animal.Type == resourceClassTemplate.Type));
                                    }
                                }
                                catch
                                {

                                }
                                try
                                {
                                    for (var i = 0; i <= numResourcesToProcessNum - 1; i++)
                                    {
                                        farm.ChickenHouses.Single(field => field.ShortId == chosenFacilityId).Resources
                                        .RemoveAt(farm.ChickenHouses.Single(field => field.ShortId == chosenFacilityId).Resources
                                        .FindIndex(animal => animal.Type == resourceClassTemplate.Type));
                                    }
                                }
                                catch
                                {

                                }
                                try
                                {
                                    for (var i = 0; i <= numResourcesToProcessNum - 1; i++)
                                    {
                                        farm.DuckHouses.Single(field => field.ShortId == chosenFacilityId).Resources
                                        .RemoveAt(farm.DuckHouses.Single(field => field.ShortId == chosenFacilityId).Resources
                                        .FindIndex(animal => animal.Type == resourceClassTemplate.Type));
                                    }
                                }
                                catch
                                {

                                }
                            }
                            else
                            {
                                Console.WriteLine("You are truly merciful...");
                            }
                        }
                        else
                        {
                            Console.WriteLine("You dont have enough of that resource to compress into that many eggs....");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid choice, rerouting to main menu");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid choice, rerouting to main menu");
                }

            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using Trestlebridge.Interfaces;
using Trestlebridge.Models;
using Trestlebridge.Models.Animals;
using Trestlebridge.Models.BaseClasses;

namespace Trestlebridge.Actions
{
    public class ChooseMeatProcessor
    {
        public static void CollectInput(Farm farm)
        {
            if (farm.ChickenHouses.Count == 0
            && farm.GrazingFields.Count == 0)
            {
                Console.WriteLine("*** Oops! You don't have any meat-producing facilities! ***");
                Console.WriteLine("*** Press return key to go back to main menu.");
                Console.ReadLine();
            }
            else
            {
                // Create list of facilities that can have eggs:
                List<Facility> FacilitiesThatHaveMeatAnimals = new List<Facility>();
                foreach (Facility facility in farm.GrazingFields)
                {
                    FacilitiesThatHaveMeatAnimals.Add(facility);
                }
                foreach (Facility facility in farm.ChickenHouses)
                {
                    FacilitiesThatHaveMeatAnimals.Add(facility);
                }

                // Show users options for facilities
                for (int i = 0; i < FacilitiesThatHaveMeatAnimals.Count; i++)
                {
                    var groupedAnimals = FacilitiesThatHaveMeatAnimals[i].Resources.GroupBy(
                        currentAnimal => currentAnimal.Type
                    );

                    var animalsString = "";
                    foreach (var group in groupedAnimals)
                    {
                        animalsString += group.Count() + " " + group.Key + ", ";
                    };


                    Console.WriteLine($"{i + 1}: {FacilitiesThatHaveMeatAnimals[i].GetType().ToString().Split(".")[FacilitiesThatHaveMeatAnimals[i].GetType().ToString().Split(".").Count() - 1]} -- {animalsString} ");
                }


                Console.WriteLine();
                Console.WriteLine($"Which facility has the animals you want to process?");
                Console.Write("> ");

                int facilityChoiceNum = Int32.Parse(Console.ReadLine()) - 1;
                if (facilityChoiceNum <= FacilitiesThatHaveMeatAnimals.Count)
                {
                    var chosenFacility = FacilitiesThatHaveMeatAnimals[facilityChoiceNum];
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
                    Console.WriteLine("Which resource would you like to GRIND INTO MEAT?");
                    Console.Write("> ");


                    int animalTypeChoiceNum = Int32.Parse(Console.ReadLine()) - 1;

                    string chosenAnimalType = chosenFacilityAnimalTypes[animalTypeChoiceNum][0].Type;
                    dynamic resourceClassTemplate = Activator.CreateInstance(chosenFacilityAnimalTypes[animalTypeChoiceNum][0].GetType());
                    double meatConversionMultiplier = ((IMeatProducing)chosenFacilityAnimalTypes[animalTypeChoiceNum][0])._meatProduced;

                    if (animalTypeChoiceNum <= chosenFacilityAnimalTypes.Count)
                    {
                        Console.WriteLine($"How many of this type of resource would you like to GRIND INTO MEAT?");
                        Console.Write("> ");

                        int numResourcesToProcessNum = Int32.Parse(Console.ReadLine());

                        if (numResourcesToProcessNum <= chosenFacilityAnimalTypes[animalTypeChoiceNum].Count)
                        {
                            int MeatReturned = numResourcesToProcessNum * Convert.ToInt32(meatConversionMultiplier);

                            Console.WriteLine($"Are you sure you want to process these into {MeatReturned} pounds of meat? (y or n)");
                            Console.WriteLine("> ");

                            string yesOrNo = Console.ReadLine();
                            if (yesOrNo == "y")
                            {
                                Console.WriteLine($"You did what you had to do. You have compressed {numResourcesToProcessNum} {chosenAnimalType} into {MeatReturned} pounds of meat...");

                                try
                                {
                                    for (var i = 0; i <= numResourcesToProcessNum - 1; i++)
                                        farm.GrazingFields.Single(field => field.ShortId == chosenFacilityId).Resources
                                        .RemoveAt(farm.GrazingFields.Single(field => field.ShortId == chosenFacilityId).Resources
                                        .FindIndex(animal => animal.Type == resourceClassTemplate.Type));

                                }
                                catch
                                {
                                }
                                try
                                {
                                    farm.PlowedFields.Single(field => field.ShortId == chosenFacilityId).Resources
                                    .RemoveAt(farm.PlowedFields.Single(field => field.ShortId == chosenFacilityId).Resources
                                    .FindIndex(animal => animal.Type == resourceClassTemplate.Type));
                                }
                                catch
                                {

                                }
                                try
                                {
                                    farm.NaturalFields.Single(field => field.ShortId == chosenFacilityId).Resources
                                    .RemoveAt(farm.NaturalFields.Single(field => field.ShortId == chosenFacilityId).Resources
                                    .FindIndex(animal => animal.Type == resourceClassTemplate.Type));
                                }
                                catch
                                {

                                }
                                try
                                {
                                    farm.ChickenHouses.Single(field => field.ShortId == chosenFacilityId).Resources
                                    .RemoveAt(farm.ChickenHouses.Single(field => field.ShortId == chosenFacilityId).Resources
                                    .FindIndex(animal => animal.Type == resourceClassTemplate.Type));
                                }
                                catch
                                {

                                }
                                try
                                {
                                    farm.DuckHouses.Single(field => field.ShortId == chosenFacilityId).Resources
                                    .RemoveAt(farm.DuckHouses.Single(field => field.ShortId == chosenFacilityId).Resources
                                    .FindIndex(animal => animal.Type == resourceClassTemplate.Type));
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
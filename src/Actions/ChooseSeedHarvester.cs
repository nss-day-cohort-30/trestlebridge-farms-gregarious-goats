using System;
using System.Collections.Generic;
using System.Linq;
using Trestlebridge.Interfaces;
using Trestlebridge.Models;
using Trestlebridge.Models.Animals;
using Trestlebridge.Models.BaseClasses;

namespace Trestlebridge.Actions
{
    public class ChooseSeedHarvester
    {
        public static void CollectInput(Farm farm)
        {
            if (farm.PlowedFields.Count == 0
            && farm.NaturalFields.Count == 0)
            {
                Console.WriteLine("*** Oops! You don't have any seed-producing facilities! ***");
                Console.WriteLine("*** Press return key to go back to main menu.");
                Console.ReadLine();
            }
            else
            {
                // Create list of facilities that can have eggs:
                List<Facility> FacilitiesThatHaveSeedProducers = new List<Facility>();
                foreach (Facility facility in farm.PlowedFields)
                {
                    FacilitiesThatHaveSeedProducers.Add(facility);
                }
                foreach (Facility facility in farm.NaturalFields)
                {
                    FacilitiesThatHaveSeedProducers.Add(facility);
                }

                // Show users options for facilities
                for (int i = 0; i < FacilitiesThatHaveSeedProducers.Count; i++)
                {
                    var groupedPlants = FacilitiesThatHaveSeedProducers[i].Resources.GroupBy(
                        currentPlant => currentPlant.Type
                    );

                    var plantString = "";
                    foreach (var group in groupedPlants)
                    {
                        plantString += group.Count() + " " + group.Key + ", ";
                    };


                    Console.WriteLine($"{i + 1}: {FacilitiesThatHaveSeedProducers[i].GetType().ToString().Split(".")[FacilitiesThatHaveSeedProducers[i].GetType().ToString().Split(".").Count() - 1]} -- {plantString} ");
                }


                Console.WriteLine();
                Console.WriteLine($"Which facility has the plants you want to process?");
                Console.Write("> ");

                int facilityChoiceNum = Int32.Parse(Console.ReadLine()) - 1;
                if (facilityChoiceNum <= FacilitiesThatHaveSeedProducers.Count)
                {
                    var chosenFacility = FacilitiesThatHaveSeedProducers[facilityChoiceNum];
                    var chosenFacilityId = chosenFacility.ShortId;
                    var chosenFacilityPlantTypes = chosenFacility.Resources
                    .GroupBy(plant => plant.Type)
                    .Select(grp => grp.ToList())
                    .ToList();
                    Console.WriteLine("The following resource types are in that facility:");
                    for (int i = 0; i < chosenFacilityPlantTypes.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}: {chosenFacilityPlantTypes[i].Count} x {chosenFacilityPlantTypes[i][0].Type}");
                    }

                    Console.WriteLine();
                    Console.WriteLine("Which resource would you like to SMASH INTO SEEDS?");
                    Console.Write("> ");


                    int PlantTypeChoiceNum = Int32.Parse(Console.ReadLine()) - 1;

                    string chosenPlantType = chosenFacilityPlantTypes[PlantTypeChoiceNum][0].Type;
                    dynamic resourceClassTemplate = Activator.CreateInstance(chosenFacilityPlantTypes[PlantTypeChoiceNum][0].GetType());
                    double seedConversionMultiplier = ((ISeedProducing)chosenFacilityPlantTypes[PlantTypeChoiceNum][0])._seedsProduced;

                    if (PlantTypeChoiceNum <= chosenFacilityPlantTypes.Count)
                    {
                        Console.WriteLine($"How many of this type of resource would you like to SMASH INTO SEEDS?");
                        Console.Write("> ");

                        int numResourcesToProcessNum = Int32.Parse(Console.ReadLine());

                        if (numResourcesToProcessNum <= chosenFacilityPlantTypes[PlantTypeChoiceNum].Count)
                        {
                            int SeedsReturned = numResourcesToProcessNum * Convert.ToInt32(seedConversionMultiplier);

                            Console.WriteLine($"Are you sure you want to process these into {SeedsReturned} seeds? (y or n)");
                            Console.WriteLine("> ");

                            string yesOrNo = Console.ReadLine();
                            if (yesOrNo == "y")
                            {
                                Console.WriteLine($"You did what you had to do. You have compressed {numResourcesToProcessNum} {chosenPlantType} into {SeedsReturned} seeds...");

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
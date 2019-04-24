using System;
using System.Collections.Generic;
using Trestlebridge.Interfaces;
using Trestlebridge.Models;
using Trestlebridge.Models.BaseClasses;
using Trestlebridge.Models.Animals;
using Trestlebridge.Models.Facilities;
using Trestlebridge.Models.Plants;

namespace Trestlebridge.Actions
{
    public class PurchaseSeeds
    {
        // This function returns a list of plants of a specific interface, based on which interfaces the users chosen plant type has (used for if the user wants to buy more than 1 plant simultaneously)
        public static List<T> MakeListOfPlants<T>(int qty, T plant)
        {
            List<T> ListOfChosenPlants = new List<T>();
            for (int i = 0; i < qty; i++)
            {
                ListOfChosenPlants.Add(plant);
            }
            return ListOfChosenPlants;
        }

        public static void CollectInput(Farm farm)
        {
            // make a list of available plant classes
            List<Plant> AvailablePlants = new List<Plant>
            {
                new Sesame(), new WildFlower(), new SunFlower()
            };
            // make a menu that mirrors the list AvailablePlants
            Console.WriteLine("1. Sesame");
            Console.WriteLine("2. Wild Flower");
            Console.WriteLine("3. Sunflower");


            Console.WriteLine();
            Console.WriteLine("What are you buying today?");

            Console.Write("> ");
            int choice = Int32.Parse(Console.ReadLine());

            // make a new object of whatever type of plant the user chose
            dynamic chosenPlantType = Activator.CreateInstance(AvailablePlants[choice - 1].GetType());

            Console.WriteLine();
            Console.WriteLine("How many would you like to plant?");

            Console.Write("> ");
            int qty = Int32.Parse(Console.ReadLine());


            // Checks to see if the plant can be planted in BOTH Plowed AND Natural fields
            if (chosenPlantType is IAnyFieldDwelling)
            {
                if (qty != 1)
                {
                    List<IAnyFieldDwelling> plants = MakeListOfPlants(qty, (IAnyFieldDwelling)chosenPlantType);
                    ChooseBothField.CollectInput(farm, plants);
                }
                else
                {
                    ChooseBothField.CollectInput(farm, (IAnyFieldDwelling)chosenPlantType);
                }
            }
            else if (chosenPlantType is IPlowedFieldDwelling)
            {
                if (qty != 1)
                {
                    List<IPlowedFieldDwelling> plants = MakeListOfPlants(qty, (IPlowedFieldDwelling)chosenPlantType);
                    ChoosePlowedField.CollectInput(farm, plants);
                }
                else
                {
                    ChoosePlowedField.CollectInput(farm, (IPlowedFieldDwelling)chosenPlantType);
                }
            }
            else
            {
                if (qty != 1)
                {
                    List<INaturalFieldDwelling> plants = MakeListOfPlants(qty, (INaturalFieldDwelling)chosenPlantType);
                    ChooseNaturalField.CollectInput(farm, plants);
                }
                else
                {
                    ChooseNaturalField.CollectInput(farm, (INaturalFieldDwelling)chosenPlantType);
                }
            }
        }
    }
}
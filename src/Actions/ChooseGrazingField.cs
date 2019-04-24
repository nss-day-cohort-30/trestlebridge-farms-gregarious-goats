using System;
using System.Linq;
using Trestlebridge.Interfaces;
using Trestlebridge.Models;
using Trestlebridge.Models.Animals;
using Trestlebridge.Models.BaseClasses;

namespace Trestlebridge.Actions {
    public class ChooseGrazingField {
        public static void CollectInput (Farm farm, IGrazing animal) {
            // Console.Clear();
            if (farm.GrazingFields.Count() == 0) {
                Console.WriteLine("*** Oops! You need to purchase a grazing field first! ***");
                Console.WriteLine("*** Press return key to go back to main menu.");
                Console.ReadLine();
            } else {
                try
                {
                    int counter = 0;
                    for (int i = 0; i < farm.GrazingFields.Count; i++)
                    {
                        // Only show facilities that are not full
                        if (farm.GrazingFields[i]._animals.Count != farm.GrazingFields[i].Capacity) {
                            var groupedAnimals = farm.GrazingFields[i]._animals.GroupBy(
                                currentAnimal => currentAnimal.Type
                                );
                            var animalsString = "";
                            foreach (var currentAnimalGroup in groupedAnimals)
                            {
                                animalsString += currentAnimalGroup.Count() + " " + currentAnimalGroup.Key + ",";
                            };
                            Console.WriteLine($"{i + 1}. Grazing Field ({animalsString})");
                        } else {
                            counter++;
                        }
                    } // If all options are full, tell user to buy another one
                        if (counter == farm.GrazingFields.Count){
                            Console.WriteLine("*** Oops! All your grazing fields are full, you need another one! ***");
                            Console.WriteLine("*** Press return key to go back to main menu.");
                            Console.ReadLine();
                        } else {
                            Console.WriteLine ();

                            Console.WriteLine ($"Place the animal where?");

                            Console.Write ("> ");
                            int choice = Int32.Parse(Console.ReadLine ());

                            farm.GrazingFields[choice - 1].AddResource(farm, animal);
                        }
                    }
                    catch (FormatException){}
            }



                /*
                    Couldn't get this to work. Can you?
                    Stretch goal. Only if the app is fully functional.
                */
                // farm.PurchaseResource<IGrazing>(animal, choice);
        }
    }
}
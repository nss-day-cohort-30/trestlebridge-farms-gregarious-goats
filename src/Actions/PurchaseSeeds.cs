using System;
using System.Collections.Generic;
using Trestlebridge.Interfaces;
using Trestlebridge.Models;
using Trestlebridge.Models.Animals;
using Trestlebridge.Models.Facilities;
using Trestlebridge.Models.Plants;

namespace Trestlebridge.Actions {
    public class PurchaseSeeds {
        public static void CollectInput (Farm farm) {
            Console.WriteLine ("1. Sesame");
            Console.WriteLine ("2. Wild Flower");
            Console.WriteLine ("3. Sunflower");

            Console.WriteLine ();
            Console.WriteLine ("What are you buying today?");

            Console.Write ("> ");
            string choice = Console.ReadLine ();

            Console.WriteLine ();
            Console.WriteLine ("How many Sunflower would you like to plant?");

            Console.Write ("> ");
            string qty = Console.ReadLine ();
            List<IPlowedFieldDwelling> SesameSeeds = new List<IPlowedFieldDwelling>();
            List<INaturalFieldDwelling> WildFlowerSeeds = new List<INaturalFieldDwelling>();
            if (Int32.Parse(choice) == 1 )
            {
                if(Int32.Parse(qty) != 1)
                {
                    for(int i=0; i < Int32.Parse(qty); i++)
                        SesameSeeds.Add(new Sesame());
                }
            }
            else
            {
                if (Int32.Parse(choice) == 2 )
                {
                    if(Int32.Parse(qty) != 1)
                    {
                        for(int i=0; i < Int32.Parse(qty); i++)
                            WildFlowerSeeds.Add(new WildFlower());
                    }
                }
            }


            switch (Int32.Parse(choice))
            {
                case 1:
                    if(Int32.Parse(qty) == 1)
                        ChoosePlowedField.CollectInput(farm, new Sesame());
                    else
                        ChoosePlowedField.CollectInput(farm, SesameSeeds);
                    break;
                case 2:
                    if(Int32.Parse(qty) == 1)
                        ChooseNaturalField.CollectInput(farm, new WildFlower());
                    else
                        ChooseNaturalField.CollectInput(farm, WildFlowerSeeds);

                    break;
                case 3:
                    ChooseBothField.CollectInput(farm, new SunFlower());
                    break;
                default:
                    break;
            }
        }
    }
}
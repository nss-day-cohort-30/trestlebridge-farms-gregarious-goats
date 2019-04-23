using System;
using System.Collections.Generic;
using System.Linq;
using Trestlebridge.Interfaces;
using Trestlebridge.Models;
using Trestlebridge.Models.Animals;

namespace Trestlebridge.Actions {
    public class ChoosePlowedField {
        public static void CollectInput (Farm farm, IPlowedFieldDwelling seed) {
            //Console.Clear();

            for (int i = 0; i < farm.PlowedFields.Count; i++)
            {
                Console.WriteLine ($"{i + 1}. Plowed Field");
            }

            Console.WriteLine ();

            // How can I output the type of animal chosen here?
            Console.WriteLine ($"Where would you like to plant the seeds?");

            Console.Write ("> ");
            int choice = Int32.Parse(Console.ReadLine ());

            farm.PlowedFields[choice-1].AddResource(seed);

            /*
                Couldn't get this to work. Can you?
                Stretch goal. Only if the app is fully functional.
             */
            // farm.PurchaseResource<IGrazing>(animal, choice);

        }
        // public static void CollectInput (Farm farm, IPlowedFieldDwelling seeds) {
        //     //Console.Clear();
        //     List<Sesame> seeds = new List<Sesame>();
        //     if(Int32.Parse(qty) != 1)
        //     {
        //         for(int i=0; i < Int32.Parse(qty); i++)
        //             seeds.Add(new Sesame());
        //     }


        //     for (int i = 0; i < farm.PlowedFields.Count; i++)
        //     {
        //         Console.WriteLine ($"{i + 1}. Plowed Field");
        //     }

        //     Console.WriteLine ();

        //     // How can I output the type of animal chosen here?
        //     Console.WriteLine ($"Where would you like to plant the seeds?");

        //     Console.Write ("> ");
        //     int choice = Int32.Parse(Console.ReadLine ());

        //     farm.PlowedFields[choice-1].AddResource(seeds);

        //     /*
        //         Couldn't get this to work. Can you?
        //         Stretch goal. Only if the app is fully functional.
        //      */
        //     // farm.PurchaseResource<IGrazing>(animal, choice);

      //  }
    }
}
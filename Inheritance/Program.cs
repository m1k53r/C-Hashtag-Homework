using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance
{
    class Program
    {

        //TODO:
        //1. explain below (in commentary) why first and second Recalcula give different results

        //explenation:
        // In first recalculate we are passing as arguments values of type IBase. This means we are using
        // function definitions of the class defined after `new` keyword.
        // In second recalculate we are passing BaseClass types and thus using function definitions from BaseClass
        //

        //2. fix inheritance mistakes and make it work as (probably) wished.

        //3. fill SetDataToAdvanced and remove coments below on this method execution

        //4. check JustSayHello methods: why is it saying the same hello in a1/a2 - we want it to be different, fix.
        //expelain why:
        // Because in C# classes aren't virtual by default and we have to add the `virtual` keyword before the 
        // parent function and `override` before child function
        //

        static void Main(string[] args)
        {
            IBase o1 = new BasicChild(1);
            IBase o2 = new Advanced(2);

            SetDataToAdvanced(o1, 3, 10);
            SetDataToAdvanced(o2, 3, 10);

            RecalculateAll(o1, o2);
            DisplayResults(o1, o2);

            BaseClass b1 = o1 as BaseClass;
            BaseClass b2 = o2 as BaseClass;

            RecalculateAll(b1, b2);
            DisplayResults(o1, o2);

            Console.WriteLine("Press any key to continue");
            Console.WriteLine("\t\twhich one is any?!");
            Console.ReadKey();


            Advanced a1 = new Advanced(1);
            Advanced a2 = new AdvancedInherited(1);

            Console.WriteLine();
            Console.WriteLine();

            a1.JustSayHello();
            a2.JustSayHello();

            Console.WriteLine("Press any key to exit");
            Console.WriteLine("\t\twhich one is any?!");
            Console.ReadKey();

        }

        private static void DisplayResults(params IBase[] objects)
        {
            Console.WriteLine($"Printing results for {objects.Length} items");

            for (int i = 0; i < objects.Length; i++)
            {
                Console.WriteLine($"Object {i}: {objects[i].Result}");
            }
        }

        private static void RecalculateAll(params BaseClass[] objects)
        {
            foreach (var item in objects)
            {
                item.AddMyValues();
            }
        }


        private static void RecalculateAll(params IBase[] objects)
        {
            foreach (var item in objects)
            {
                item.AddMyValues();
            }
        }

        /// <summary>
        /// set given multi and add to o if it is advanced interface;
        /// </summary>
        /// <param name="o1"></param>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        private static void SetDataToAdvanced(IBase o, int multi, int add)
        {
            if (o is IAdvanced advancedO)
            {
                advancedO.SetMultiplier(multi);
                advancedO.SetAdd(add);
            }
        }
    }
}

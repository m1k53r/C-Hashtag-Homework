using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optimization
{
    class Program
    {
        private static Data[] datas = new Data[1000];


        //it is possible to get the score around 1000ms in a single thread (release configuration launched without debuging from release folder!) - try to do that :) 
        //using multithreading is possible, but there is no focus on that in this case

        static void Main(string[] args)
        {
            for (int i = 0; i < datas.Length; i++)
            {
                datas[i] = new Data();
            }

            var st = DateTime.Now;
            Calculate();
            var en = DateTime.Now;

            Console.WriteLine($"calculations took {(en - st).TotalMilliseconds}ms");

            Console.WriteLine("Press any key to exit");
            Console.WriteLine("\t\twhich one is any?!");
            Console.ReadKey();
        }

        private static void Calculate()
        {
            for (int i = 0; i < datas.Length; i++)
            {
                List<int> results = new List<int>();

                var r = new Random();
                foreach (var d in datas)
                {
                    results.Add(d.Calculate(r.Next(1000)));
                }

                var resultsOrdered = results.OrderBy(x => (x * x) / 2.0 - x);
            }
        }
    }
}

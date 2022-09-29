using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Multithreading
{
    class Program
    {
        static void Main(string[] args)
        {
            var data = new Data();

            var preproc = new Preprocess(data);
            var calc = new Calculate(data);
            var display = new Display(data);

            var t1 = new Thread(preproc.Start);
            var t2 = new Thread(calc.Start);
            var t3 = new Thread(display.Start);

            //TODO: start all stuff in new threads
            //Display should wait for calculate to calculate, and calculate needs to wait for preprocess to finish preprocessing
            //(so basically except of parallel processing some sort of syncronization is required!)
            t1.Start();
            t1.Join();
            t2.Start();
            t2.Join();
            t3.Start();
            t3.Join();
            /*
            Task.Factory.StartNew(() => preproc.Start()).Wait();
            Task.Factory.StartNew(() => calc.Start()).Wait();
            Task.Factory.StartNew(() => display.Start()).Wait();
            */
            //TODO: wait for all threads to finish


            Console.WriteLine("Press any key to exit");
            Console.WriteLine("\t\twhich one is any?!");
            Console.ReadKey();
        }
    }
}

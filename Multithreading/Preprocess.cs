using System;
using System.Threading;

namespace Multithreading
{
    internal class Preprocess
    {
        private Data data;

        public Preprocess(Data data)
        {
            this.data = data;
        }

        public void DoPreprocess()
        {
            ScaleToRange(-10.0, 10.0);
            //TODO: data can be calculated now
            SaveResultsToDatabase();
            DoSomethingElseThatTakesTime();
        }

        private void DoSomethingElseThatTakesTime()
        {
            //FAKE
            Thread.Sleep(2000);
            Console.WriteLine("Preprocess: doing something else that takes time finished");
        }

        internal void Start()
        {
            DoPreprocess();
        }

        private void SaveResultsToDatabase()
        {
            //FAKE
            Thread.Sleep(2000);
            Console.WriteLine("Preprocess: data saved to database");
        }

        private void ScaleToRange(double from, double to)
        {
            for (int i = 0; i < data.DataRawArray.Length; i++)
            {
                data.DataPreprocessedArray[i] = data.DataRawArray[i] * (to - from);
            }

            Thread.Sleep(5000);
            Console.WriteLine("Finished preprocessing calculations");
        }
    }
}
using System;
using System.Threading;

namespace Multithreading
{
    internal class Calculate
    {
        private Data data;

        public Calculate(Data data)
        {
            this.data = data;
        }

        internal void Start()
        {
            DoCalculate();
        }

        private void DoCalculate()
        {
            CalculatePowers();
            //TODO: data can be displayed now
            SaveToDatabase();
        }

        private void SaveToDatabase()
        {
            //FAKE
            Thread.Sleep(3000);
            Console.WriteLine("Calculate: calculated data saved to DB");
        }

        private void CalculatePowers()
        {
            for (int i = 0; i < data.DataRawArray.Length; i++)
            {
                data.DataCalculatedArray[i] = Math.Pow(Math.E, Math.PI * data.DataPreprocessedArray[i]);
            }
            Thread.Sleep(1000);
            Console.WriteLine("Calculate: Data Calculated");
        }
    }
}
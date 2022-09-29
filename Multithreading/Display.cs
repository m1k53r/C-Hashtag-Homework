using System;
using System.Linq;

namespace Multithreading
{
    internal class Display
    {
        private Data data;

        public Display(Data data)
        {
            this.data = data;
        }

        internal void Start()
        {
            DoDisplay();
        }

        private void DoDisplay()
        {
            var avgRaw = data.DataRawArray.Average(x => x);
            var avgPreprocessed = data.DataPreprocessedArray.Average(x => x);
            var avgCalculated = data.DataCalculatedArray.Average(x => x);

            Console.WriteLine($"Avg Raw: {avgRaw}\nAvg Preprocessed: {avgPreprocessed}\nAvg Calculated: {avgCalculated}");
        }
    }
}
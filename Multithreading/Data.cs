using System;

namespace Multithreading
{
    internal class Data
    {
        readonly double[] dataRaw = new double[1024];
        readonly double[] dataPreprocessed = new double[1024];
        readonly double[] dataCalculated = new double[1024];

        public Data()
        {
            var r = new Random();
            for (int i = 0; i < dataRaw.Length; i++)
            {
                dataRaw[i] = r.NextDouble();
            }
        }

        public double[] DataRawArray { get { return dataRaw; } }
        public double[] DataPreprocessedArray { get { return dataPreprocessed; } }
        public double[] DataCalculatedArray { get { return dataCalculated; } }

    }
}
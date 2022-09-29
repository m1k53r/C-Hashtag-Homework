using System;

namespace Optimization
{
    internal class Data
    {
        public int A { get; set; }
        public int B { get; set; }
        public int C { get; set; }

        public Data()
        {
            var r = new Random();
            A = r.Next(100);
            B = r.Next(100);
            C = r.Next(100);
        }

        public int Calculate(int x)
        {
            return A * A * B * B * C * C * x;
        }

    }
}
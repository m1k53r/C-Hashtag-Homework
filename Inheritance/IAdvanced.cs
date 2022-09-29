using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance
{
    interface IAdvanced
    {
        int Multiplier { get; }
        int Add { get; }

        void SetMultiplier(int mutliplier);
        void SetAdd(int add);
    }
}

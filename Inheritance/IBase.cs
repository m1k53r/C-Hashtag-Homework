using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance
{
    interface IBase
    {
        int MyValue { get; set; }
        int Result { get; }

        void AddMyValues();
    }
}

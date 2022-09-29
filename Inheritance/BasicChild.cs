using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance
{
    internal class BasicChild : BaseClass, IBase
    {
        public override int MyClassValue { get; protected set; } = 10;
        public int MyOtherValue { get; protected set; } = 15;

        public BasicChild(int val) : base(val)
        {
        }

        public override void AddMyValues()
        {
            base.AddMyValues();
            result += MyOtherValue;
        }
    }
}

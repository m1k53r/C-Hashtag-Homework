using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance
{
    class Advanced : BaseClass, IAdvanced
    {
        public int Multiplier { get; private set; }

        public int Add { get; private set; }

        public void SetAdd(int add)
        {
            Add = add;
        }

        public void SetMultiplier(int mutliplier)
        {
            Multiplier = mutliplier;
        }

        public override int MyClassValue { get; protected set; } = 20;

        public Advanced(int val) : base(val)
        {

        }

        public override void AddMyValues()
        {
            result = MyClassValue * Multiplier + MyValue * Multiplier + Add;
        }


        public virtual void JustSayHello()
        {
            Console.WriteLine("Hello, i'm Advanced!");
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance
{
    abstract class BaseClass : IBase
    {
        public int MyValue { get; set; }

        public virtual int MyClassValue { get; protected set; } = 5;

        public int Result
        {
            get
            {
                if (result.HasValue)
                    return result.Value;
                throw new Exception("Not yet calculated");
            }
        }

        public int? result = null;

        public BaseClass(int val)
        {
            MyValue = val;
        }

        public virtual void AddMyValues()
        {
            result = MyValue + MyClassValue;
        }
    }
}

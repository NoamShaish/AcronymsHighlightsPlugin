using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestAssembly
{
    public class Class1 : TestAssembly.TestInterface
    {
        public Class1() { }
        public string Identify()
        {
            return "Class1";
        }
    }
}

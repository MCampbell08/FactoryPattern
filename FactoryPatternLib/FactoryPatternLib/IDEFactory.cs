using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryPatternLib
{
    public abstract class IDEFactory
    {
        public abstract void Compile();
        public abstract void Display();
    }
}

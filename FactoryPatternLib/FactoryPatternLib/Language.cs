using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryPatternLib
{
    public abstract class Language
    {
        public abstract void Compile();
        public abstract void Display();
        public abstract void CreateComponent();
    }
}

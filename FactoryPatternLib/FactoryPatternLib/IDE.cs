using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryPatternLib
{
    public class IDE
    {
        private LanguageFactory _IDEFactory { get; set; }
        public IDE(LanguageFactory iDEFactory)
        {
            _IDEFactory = iDEFactory;
        }
    }
}
    
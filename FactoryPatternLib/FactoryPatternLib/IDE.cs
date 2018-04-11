using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryPatternLib
{
    public class IDE
    {
        private IDEFactory _IDEFactory { get; set; }
        public IDE(IDEFactory iDEFactory)
        {
            _IDEFactory = iDEFactory;
        }
    }
}

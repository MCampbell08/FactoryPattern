using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryPatternLib
{
    public class IDE
    {
        private Language _IDEFactory { get; set; }
        public IDE(Language iDEFactory)
        {
            _IDEFactory = iDEFactory;
        }
    }
}

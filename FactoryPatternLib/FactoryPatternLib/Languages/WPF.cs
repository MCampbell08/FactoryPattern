using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryPatternLib
{
    public class WPF : LanguageFactory
    {
        public override ObservableCollection<UI_Component> Components { get => Components; set => Components = value; }

        public override void Compile()
        {
            throw new NotImplementedException();
        }

        public override void CreateComponent()
        {
            throw new NotImplementedException();
        }

        public override void Display()
        {
            throw new NotImplementedException();
        }
    }
}

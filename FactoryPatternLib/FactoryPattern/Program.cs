using FactoryPatternLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryPattern
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //UserInterface userInterface = new UserInterface();

            //userInterface.Run();

            HTML l = new HTML();
            l.Compile();
            l.Display();
        }
    }
}

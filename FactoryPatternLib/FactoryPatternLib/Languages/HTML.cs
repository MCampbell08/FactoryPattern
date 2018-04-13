using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryPatternLib
{
    public class HTML : LanguageFactory
    {
        public override void Compile()
        {
            using (FileStream fileStream = new FileStream("../testFile.html", FileMode.Create))
            {
                using (StreamWriter streamWriter = new StreamWriter(fileStream, Encoding.UTF8))
                {
                    streamWriter.Write("<!DOCTYPE HTML>\n" +
                                                "<html>\n" +
                                                "</html>");
                }
            }
        }

        public override List<Tuple<Component, double, double, string, double, double>> Components { get => Components; set => Components = value; }

        public override void CreateComponent()
        {
            for (int x = 0; x < Components.Count; x++)
            { 
                switch (Components[x].Item1)
                {
                    case Component.BUTTON:
                        Button button = new Button();
                        break;
                    case Component.CIRCLE:
                        Circle circle = new Circle();
                        break;
                    case Component.IMAGE:
                        Image image = new Image();
                        break;
                    case Component.TEXTBOX:
                        Textbox textbox = new Textbox();
                        break;
                }
            }
        }

        public override void Display()
        {
            System.Diagnostics.Process.Start("C:\\Users\\Blake\\Documents\\FactoryPattern\\FactoryPatternLib\\FactoryPattern\\bin\\testFile.html");
        }   
    }
}

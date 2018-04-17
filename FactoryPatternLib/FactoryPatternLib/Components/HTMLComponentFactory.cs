using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryPatternLib.Components
{
    public class HTMLComponentFactory : ComponentFactory
    {
        public override void Compile(ObservableCollection<Component> observableCollection)
        {
            using (FileStream fileStream = new FileStream("C:\\FactoryPattern\\FactoryPatternLib\\FactoryPatternLib\\testFile.html", FileMode.Create))
            {
                using (StreamWriter streamWriter = new StreamWriter(fileStream, Encoding.UTF8))
                {
                    streamWriter.Write("<!DOCTYPE HTML>\n" +
                                                "<html>\n" +
                                                "<body>\n" +
                                                TagStrings(observableCollection) +
                                                "</body>\n" +
                                                "</html>");
                }
            }
        }


        public override Component CreateComponent(Enums.Components component, double height, double width, double leftLoc, double topLoc, string content)
        {
            Component c = null;

            if (component == Enums.Components.Button)
                c = new HTMLButton() { Content = content, Height = height, Width = width, TopLoc = topLoc, LeftLoc = leftLoc };
            else if (component == Enums.Components.Circle)
                c = new Circle() { Content = content, Height = height, Width = width, TopLoc = topLoc, LeftLoc = leftLoc };
            else if (component == Enums.Components.Image)
                c = new Image() { Content = content, Height = height, Width = width, TopLoc = topLoc, LeftLoc = leftLoc };
            else if (component == Enums.Components.Textbox)
                c = new HTMLTextbox() { Content = content, Height = height, Width = width, TopLoc = topLoc, LeftLoc = leftLoc };
            
            return c;
        }

        public override void Display()
        {
            System.Diagnostics.Process.Start("C:\\FactoryPattern\\FactoryPatternLib\\FactoryPatternLib\\testFile.html");
        }

        private string TagStrings(ObservableCollection<Component> observableCollection)
        {
            StringBuilder stringBuilder = new StringBuilder();

            foreach (Component component in observableCollection)
                stringBuilder.Append(component.ComponentString());

            return stringBuilder.ToString();
        }
    }
}

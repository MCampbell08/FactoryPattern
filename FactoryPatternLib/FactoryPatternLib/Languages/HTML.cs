using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FactoryPatternLib.Enums;
using System.Collections.ObjectModel;

namespace FactoryPatternLib
{
    public class HTML : LanguageFactory
    {
        private ObservableCollection<Components.Component> components = new ObservableCollection<Components.Component>();
        private string componentWTags = "";
        public override void Compile()
        {
            using (FileStream fileStream = new FileStream("C:\\FactoryPattern\\FactoryPatternLib\\FactoryPatternLib\\testFile.html", FileMode.Create))
            {
                using (StreamWriter streamWriter = new StreamWriter(fileStream, Encoding.UTF8))
                {
                    streamWriter.Write("<!DOCTYPE HTML>\n" +
                                                "<html>\n" +
                                                "<body>\n" +
                                                componentWTags+
                                                "</body>\n"+
                                                "</html>");
                }
            }
        }

        public override ObservableCollection<Components.Component> Components { get => components; set => components = Components; }

        public override void CreateComponent()
        {
            foreach (Components.Component component in Components)
            {
                if (component is Button)
                {
                    componentWTags += $"<button style=\" position:absolute; left:{component.LeftLoc}px; top:{component.TopLoc}px; height:{component.Height}px; width:{component.Width}px;\">{component.Content}</button>\n";
                }
                else
                switch (component)
                {
                    case Button:
                        break;
                    case Enums.Component.CIRCLE:
                        componentWTags += $"<canvas id=\"myCanvas\"  width=\"1000\" height=\"1000\" style=\"border: 1px solid #d3d3d3;\"></canvas>\n" +
                            $"<script>\n" +
                            $"var c = document.getElementById('myCanvas');\n" +
                            $"var ctx = c.getContext(\"{component.Content}\")\n" +
                            $"ctx.beginPath();\n" +
                            $"ctx.arc({component.LeftLoc}, {component.TopLoc}, {component.Width / 2}, 0, 2 * 3.14);\n" +
                            $"ctx.stroke();\n" +
                            $"</script>";
                        break;
                    case Enums.Component.TEXTBOX:
                        componentWTags += $"<input type=\"text\" style=\" position:absolute; left:{component.LeftLoc}px; top:{component.TopLoc}px; height:{component.Height}px; width:{component.Width}px;\" value=\"{component.Content}\"></input>\n";
                        break;
                    case Enums.Component.IMAGE:
                        componentWTags += $"<img src=\"{component.Content}\" alt=\"valid image path\"style=\" position:absolute; left:{component.LeftLoc}px; top:{component.TopLoc}px; height:{component.Height}px; width:{component.Width}px;\" ";
                        break;
                }
            }
        }

        public override void Display()
        {
            System.Diagnostics.Process.Start("C:\\FactoryPattern\\FactoryPatternLib\\FactoryPatternLib\\testFile.html");
        }   
    }
}

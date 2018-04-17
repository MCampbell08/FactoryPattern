using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryPatternLib
{
    public class WPF : LanguageFactory
    {
        private ObservableCollection<UI_Component> components = new ObservableCollection<UI_Component>();
        private string componentWTags = "";
        public override ObservableCollection<UI_Component> Components { get => components; set => components = value; }
        public object UIElement { get; private set; }

        public override void Compile()
        {
            using (FileStream fileStream = new FileStream("C:\\FactoryPattern\\FactoryPatternLib\\FactoryPatternLib\\MainWindow.xaml", FileMode.Create))
            {
                using (StreamWriter streamWriter = new StreamWriter(fileStream, Encoding.UTF8))
                {
                    streamWriter.Write("<Window \n" +
                        "xmlns = \"http://schemas.microsoft.com/winfx/2006/xaml/presentation\"\n" +
                        "xmlns:x= \"http://schemas.microsoft.com/winfx/2006/xaml\"\n" +
                        "xmlns:d= \"http://schemas.microsoft.com/expression/blend/2008\"\n" +
                        "xmlns:mc= \"http://schemas.openxmlformats.org/markup-compatibility/2006\"\n" +
                        "mc:Ignorable=\"d\"\n" +
                        "Title=\"TestWindow\" Height=\"350\" Width=\"550\">\n" +
                        "<StackPanel Name=\"mainStackPanel\">\n" +
                        $"{componentWTags}\n" +
                        "</StackPanel>\n" +
                        "</Window>");
                }
            }
        }

        public override void CreateComponent()
        {
            foreach (UI_Component component in Components)
            {
                switch (component.Component)
                {
                    case Enums.Component.BUTTON:
                        componentWTags += $"<Button Name=\"button\" Height=\"{component.Height}\" Width=\"{component.Width}\" Content=\"{component.Content}\" Margin=\"{component.LeftLoc}, {component.TopLoc}, 0, 0\"/>";
                        break;
                    case Enums.Component.CIRCLE:
                        componentWTags += $"";
                        break;
                    case Enums.Component.TEXTBOX:
                        componentWTags += $"<TextBox Name=\"textbox\" Height=\"{component.Height}\" Width=\"{component.Width}\" Text=\"{component.Content}\" Margin=\"{component.LeftLoc}, {component.TopLoc}, 0, 0\"/>";
                        break;
                    case Enums.Component.IMAGE:
                        componentWTags += $"";
                        break;
                }
            }
        }

        public override void Display()
        {
            //System.Diagnostics.Process process = new System.Diagnostics.Process();
            //System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            //startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            //startInfo.FileName = "cmd.exe";
            //startInfo.Arguments = "csc.exe /out:WPFApplication.exe /target:winexe app.cs C:\\FactoryPattern\\FactoryPatternLib\\FactoryPatternLib\\MainWindow.xaml /reference:\"C:\\Program Files\\Reference Assemblies\\Microsoft\\Framework\\v3.0\\presentationframework.dll\" /reference:\"C:\\Program Files\\Reference Assemblies\\Microsoft\\Framework\\v3.0\\windowsbase.dll\" /reference:\"C:\\Program Files\\Reference Assemblies\\Microsoft\\Framework\\v3.0\\presentationcore.dll\"";
            //process.StartInfo = startInfo;
            //process.Start();
        }
    }
}

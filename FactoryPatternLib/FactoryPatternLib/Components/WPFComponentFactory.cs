using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace FactoryPatternLib.Components
{
    public class WPFComponentFactory : ComponentFactory
    {
        public override void Compile(ObservableCollection<Component> observableCollection)
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
                        $"{TagStrings(observableCollection)}\n" +
                        "</StackPanel>\n" +
                        "</Window>");
                }
            }
        }

        public override Component CreateComponent(Enums.Components component, double height, double width, double leftLoc, double topLoc, string content)
        {
            Component c = null;

            if (component == Enums.Components.Button)
                c = new Button() { Content = content, Height = height, Width = width, TopLoc = topLoc, LeftLoc = leftLoc };
            else if (component == Enums.Components.Textbox)
                c = new Textbox() { Content = content, Height = height, Width = width, TopLoc = topLoc, LeftLoc = leftLoc };
            
            return c;
        }

        public override void Display()
        {
            FileStream fileStream = new FileStream("C:\\FactoryPattern\\FactoryPatternLib\\FactoryPatternLib\\MainWindow.xaml", FileMode.OpenOrCreate);
            Window window = (Window)System.Windows.Markup.XamlReader.Load(fileStream);
            window.Show();
            fileStream.Close();
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

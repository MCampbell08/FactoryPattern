using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using FactoryPatternLib.Enums;
using System.Collections.ObjectModel;
using FactoryPatternLib.Components;
using System.IO;
using System.Windows.Markup;
using FactoryPatternLib;

namespace FactoryPatternUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string availableComponentSelected;
        private string selectedComponentSelected;

        public ObservableCollection<Component> TempComponents { get; set; }
        private ComponentFactory componentFactory;

        public MainWindow()
        {
            InitializeComponent();
            InitializeUIObjects();
        }
        private void InitializeUIObjects()
        {
            languageBox.ItemsSource = new ObservableCollection<string>() { "HTML", "WPF" };

            if (languageBox.SelectedValue.ToString().ToLower() == "html") 
                componentFactory = new HTMLComponentFactory();
            else if (languageBox.SelectedValue.ToString().ToLower() == "wpf")
                componentFactory = new WPFComponentFactory();

            availableComponentsListBox.ItemsSource = componentFactory.Components();
        }

        private void AvailableComponentsListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListBox tempListBox = (ListBox) e.Source;
            availableComponentSelected = tempListBox.SelectedItem.ToString();
        }
        private void SelectedComponentsListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListBox tempListBox = (ListBox)e.Source;

            if (tempListBox.SelectedItem != null) 
                selectedComponentSelected = tempListBox.SelectedItem.ToString();
            
        }

        private void AddComponentButton_Click(object sender, RoutedEventArgs e)
        {
            if(availableComponentSelected != null)
            {
                ObservableCollection<string> tempListItems = (this.selectedComponentsListBox.Items.Count > 0) ? (ObservableCollection<string>)this.selectedComponentsListBox.Items.SourceCollection : new ObservableCollection<string>();
                tempListItems.Add(availableComponentSelected);

                this.selectedComponentsListBox.ItemsSource = tempListItems;
            }
        }

        private void Edit_RemoveComponentButton_Click(object sender, RoutedEventArgs e)
        {
            if (selectedComponentSelected != null)
            {
                EditWindow editWindow = new EditWindow(this);

                editWindow.Show();
            }
        }
        public void SaveComponent(double topLoc, double leftLoc, double height, double width, string content)
        {
            if (TempComponents == null)
                TempComponents = new ObservableCollection<Component>();
            if (selectedComponentSelected.ToLower() == "button")
                TempComponents.Add(new FactoryPatternLib.Button() {TopLoc = topLoc, LeftLoc = leftLoc, Height = height, Width = width, Content = content });
            else if (selectedComponentSelected.ToLower() == "circle")
                TempComponents.Add(new Circle() {TopLoc = topLoc, LeftLoc = leftLoc, Height = height, Width = width, Content = content });
            else if (selectedComponentSelected.ToLower() == "textbox")
                TempComponents.Add(new Textbox() {TopLoc = topLoc, LeftLoc = leftLoc, Height = height, Width = width, Content = content });
            else if (selectedComponentSelected.ToLower() == "image")
                TempComponents.Add(new FactoryPatternLib.Image() {TopLoc = topLoc, LeftLoc = leftLoc, Height = height, Width = width, Content = content });
        }

        private void RunProject_Click(object sender, RoutedEventArgs e)
        {
            if(TempComponents.Count > 0 && languageBox.SelectedIndex != -1)
            {
                LanguageFactory languageFactory;

                if (languageBox.SelectedValue.ToString().ToLower().Equals("wpf"))
                    languageFactory = new WPF();
                else 
                    languageFactory = new HTML();

                foreach (Component component in TempComponents)
                    languageFactory.Components.Add(component);
                
                languageFactory.CreateComponent();
                languageFactory.Compile();
                languageFactory.Display();

                if (languageFactory is WPF) {
                    FileStream fileStream = new FileStream("C:\\FactoryPattern\\FactoryPatternLib\\FactoryPatternLib\\MainWindow.xaml", FileMode.OpenOrCreate);
                    Window window = (Window)XamlReader.Load(fileStream);
                    window.Show();
                    fileStream.Close();
                }
            }
        }
    }
}

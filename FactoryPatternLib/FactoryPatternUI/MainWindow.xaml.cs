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
using System.Windows.Controls.Primitives;

namespace FactoryPatternUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string availableComponentSelected;
        private string selectedComponentSelected;
        private string selectedLanguaged;

        public ObservableCollection<Component> TempComponents { get; set; }
        public ObservableCollection<Component> Components { get; set; }
        private ComponentFactory componentFactory;

        public MainWindow()
        {
            InitializeComponent();
            InitializeUIObjects();
        }
        private void InitializeUIObjects()
        {
            languageBox.ItemsSource = new ObservableCollection<string>() { "HTML", "WPF" };
            availableComponentsListBox.ItemsSource = new ObservableCollection<string>() { "Button", "Textbox", "Circle", "Image" };
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
            if (componentFactory != null) {
                if (Components == null)
                    Components = new ObservableCollection<Component>();

                if (selectedComponentSelected.ToLower() == "button")
                    Components.Add(componentFactory.CreateComponent(FactoryPatternLib.Enums.Components.Button, height, width, topLoc, leftLoc, content));
                else if (selectedComponentSelected.ToLower() == "circle")
                    Components.Add(componentFactory.CreateComponent(FactoryPatternLib.Enums.Components.Circle, height, width, topLoc, leftLoc, content));
                else if (selectedComponentSelected.ToLower() == "textbox")
                    Components.Add(componentFactory.CreateComponent(FactoryPatternLib.Enums.Components.Textbox, height, width, topLoc, leftLoc, content));
                else if (selectedComponentSelected.ToLower() == "image")
                    Components.Add(componentFactory.CreateComponent(FactoryPatternLib.Enums.Components.Image, height, width, topLoc, leftLoc, content));
            }
            else
            {
                ObservableCollection<string> list = (ObservableCollection<string>)selectedComponentsListBox.ItemsSource;

                list.Remove(selectedComponentsListBox.SelectedValue.ToString());
                selectedComponentsListBox.ItemsSource = list;
            }
        }

        private void RunProject_Click(object sender, RoutedEventArgs e)
        {
            if(Components.Count > 0 && languageBox.SelectedIndex != -1)
            {
                componentFactory.Compile(Components);
                componentFactory.Display();
            }
        }

        private void LanguageBox_Selected(object sender, RoutedEventArgs e)
        {
            ComboBox comboBox = (ComboBox)e.Source;
            if ((selectedLanguaged = comboBox.SelectedValue.ToString().ToLower()) == "wpf")
                componentFactory = new WPFComponentFactory();
            else if ((selectedLanguaged = comboBox.SelectedValue.ToString().ToLower()) == "html")
                componentFactory = new HTMLComponentFactory();
            
            if(Components != null)
                Components.Clear();
        }
    }
}

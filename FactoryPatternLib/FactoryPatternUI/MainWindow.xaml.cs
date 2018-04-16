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

        public ObservableCollection<UI_Component> TempComponents { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            InitializeUIObjects();
        }
        private void InitializeUIObjects()
        {
            languageBox.ItemsSource = new ObservableCollection<string>() { "HTML", "WPF" };
            availableComponentsListBox.ItemsSource = new ObservableCollection<string>() { "Button", "Circle", "Image", "Textbox" };
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
                TempComponents = new ObservableCollection<UI_Component>();
            if (selectedComponentSelected.ToLower() == "button")
                TempComponents.Add(new FactoryPatternLib.Button() { Component = Component.BUTTON, TopLoc = topLoc, LeftLoc = leftLoc, Height = height, Width = width, Content = content });
            else if (selectedComponentSelected.ToLower() == "circle")
                TempComponents.Add(new FactoryPatternLib.Circle() { Component = Component.CIRCLE, TopLoc = topLoc, LeftLoc = leftLoc, Height = height, Width = width, Content = content });
            else if (selectedComponentSelected.ToLower() == "textbox")
                TempComponents.Add(new FactoryPatternLib.Textbox() { Component = Component.TEXTBOX, TopLoc = topLoc, LeftLoc = leftLoc, Height = height, Width = width, Content = content });
            else if (selectedComponentSelected.ToLower() == "image")
                TempComponents.Add(new FactoryPatternLib.Image() { Component = Component.IMAGE, TopLoc = topLoc, LeftLoc = leftLoc, Height = height, Width = width, Content = content });
        }

        private void RunProject_Click(object sender, RoutedEventArgs e)
        {
            if(TempComponents.Count > 0 && languageBox.SelectedIndex != -1)
            {
                LanguageFactory languageFactory;

                if (languageBox.SelectedIndex.ToString().ToLower() == "wpf")
                    languageFactory = new WPF();
                else
                    languageFactory = new HTML();

                foreach (UI_Component component in TempComponents)
                    languageFactory.Components.Add(component);
                
                languageFactory.CreateComponent();
                languageFactory.Compile();
            }
        }
    }
}

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

namespace FactoryPatternUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string availableComponentSelected;
        private string selectedComponentSelected;
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
            //TODO: check for null on selected item
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
    }
}

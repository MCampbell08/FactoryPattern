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

namespace FactoryPatternUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void InitializeUIObjects()
        {
            ListBox availableListBox = this.availableComponentsListBox;
            List<string> availableListBoxItems = 

            availableComponentsListBox.DataContext = 
        }

        private void AvailableComponentsListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        private void SelectedComponentsListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}

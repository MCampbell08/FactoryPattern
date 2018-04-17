using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Shapes;

namespace FactoryPatternUI
{
    /// <summary>
    /// Interaction logic for EditWindow.xaml
    /// </summary>
    
    public partial class EditWindow : Window
    {
        private string prevText = "";
        private MainWindow mainWindow;
        public EditWindow(MainWindow mainWindow)
        {
            InitializeComponent();
            this.mainWindow = mainWindow;
        }

        private void TextBox_DataContextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = (TextBox)e.Source;
            
            foreach(char c in textBox.Text)
            {
                if ((c >= 'a' && c <= 'z') || (c >= 'A' && c <= 'Z'))
                    textBox.Text = prevText;
            }
            prevText = textBox.Text;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (topLocBox.Text != "" && leftLocBox.Text != "" && heightLocBox.Text != "" && widthLocBox.Text != "" && contentLocBox.Text != "") {
                mainWindow.SaveComponent(Double.Parse(topLocBox.Text), Double.Parse(leftLocBox.Text), Double.Parse(heightLocBox.Text), Double.Parse(widthLocBox.Text), contentLocBox.Text);

                Close();
            }
        }

        private void RemoveButton_Click(object sender, RoutedEventArgs e)
        {
            ObservableCollection<string> list = (ObservableCollection<string>)mainWindow.selectedComponentsListBox.ItemsSource;

            list.Remove(mainWindow.selectedComponentsListBox.SelectedValue.ToString());
            mainWindow.selectedComponentsListBox.ItemsSource = list;

            Close();
        }
    }
}

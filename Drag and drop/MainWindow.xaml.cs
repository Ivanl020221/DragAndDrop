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

namespace Drag_and_drop
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<User> users = new List<User> { new User { Name = "Ivanov", BirthDate = DateTime.Now }, new User { BirthDate = DateTime.Now, Name = "Sidorov" } };

        public MainWindow()
        {
            InitializeComponent();
            System.Windows.Forms.MaskedTextBox masked = new System.Windows.Forms.MaskedTextBox();
            masked.Mask = "00-00-00$";
            Mask.Child = masked;
            Test.ItemsSource = users;
            Test.MouseDown += this.Test_MouseDown;
            Test.SelectionChanged += this.Test_SelectionChanged;
            Tests.Drop += this.Tests_Drop;
        }

        private void Test_SelectionChanged(object sender, SelectionChangedEventArgs e) => DragDrop.DoDragDrop((ListBox)sender, (((ListBox)sender).SelectedItem as User).Name, DragDropEffects.All); 
        private void Tests_Drop(object sender, DragEventArgs e) => ((TextBox)sender).Text = (e.Source as string);

        private void Test_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragDrop.DoDragDrop((Label)sender, ((Label)sender).Content, DragDropEffects.Link);
        }

      
    }

    public class User
    {
        public string Name { get; set; }

        public DateTime BirthDate { get; set; }
    }
}

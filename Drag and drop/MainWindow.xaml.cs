using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms.DataVisualization.Charting;
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
//0: Позволяет вводить только цифры
//9: Позволяет вводить цифры и пробелы
//#: Позволяет вводить цифры, пробелы и знаки '+' и '-' 
//L: Позволяет вводить только буквенные символы
//?: Позволяет вводить дополнительные необязательные буквенные символы
//A: Позволяет вводить буквенные и цифровые символы 
//.: Задает позицию разделителя целой и дробной части
//,: Используется для разделения разрядов в целой части числа
//::Используется в временных промежутках - разделяет часы, минуты и секунды
///: Используется для разделения дат 
//$: Используется в качестве символа валюты
            Mask.Child = masked;
            Test.ItemsSource = users;
            Test.MouseDown += this.Test_MouseDown;
            Test.SelectionChanged += this.Test_SelectionChanged;
            Tests.Drop += this.Tests_Drop;
            //System.Windows.Forms.DataVisualization.Charting.Chart chart = new Chart();
            //chart.Series.Add("ser1");
            //chart.DataSource = users;
            //chart.Series["ser1"].XValueMember = "Name";
            //chart.Series["ser1"].YValueMembers = "BirthDate";

            //chart.Titles.Add("Users");
            //chart.Series["ser1"].ChartType = SeriesChartType.Pie;

            //chart.Series["ser1"].IsValueShownAsLabel = true;
            //NewChart.Child = chart;
            //PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(typeof(User));
            var a = ValidError.x0A;
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

    public enum ValidError
    {
        /// <summary>
        /// Все прошло удачно
        /// </summary>
        x0A,
        /// <summary>
        /// Ошибка пароля
        /// </summary>
        x1A
    }
}

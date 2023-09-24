using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace SportsCalendar
{
    /// <summary>
    /// Логика взаимодействия для ListPage.xaml
    /// </summary>
    public partial class ListPage : Page
    {
        bool[] sports;
        public ListPage()
        {
            InitializeComponent();

            if (CalendarPage.Accounting.ContainsKey(CalendarPage.SelectedDate))
                sports = CalendarPage.Accounting[CalendarPage.SelectedDate].Exercises;
            else
                sports = new bool[6];

            for (int i = 0; i < sports.Length; i++)
            {
                var checkBox = (CheckBox)FindName("comboBox" + (i + 1).ToString());
                checkBox.IsChecked = sports[i] ? true : false;       
            }

            labelDate.Content = CalendarPage.GetMonth(CalendarPage.SelectedDate.Month) 
                + " " + CalendarPage.SelectedDate.Day
                + "\n" + CalendarPage.SelectedDate.Year;
        }

        private void buttonSaveAndBack_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < sports.Length; i++)
            {
                var checkBox = (CheckBox)FindName("comboBox" + (i + 1).ToString());
                sports[i] = checkBox.IsChecked == true ? true : false;
            }

            if (CalendarPage.Accounting.ContainsKey(CalendarPage.SelectedDate))
                CalendarPage.Accounting.Remove(CalendarPage.SelectedDate);
            
            CalendarPage.Accounting.Add(CalendarPage.SelectedDate, new Sport(sports));

            // сериализация заметок
            File.WriteAllText("accounting.json", JsonConvert.SerializeObject(CalendarPage.Accounting));

            NavigationService.Navigate(new CalendarPage());
        }

        private void buttonBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new CalendarPage());
        }
    }
}

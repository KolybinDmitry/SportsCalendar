using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;

namespace SportsCalendar
{
    public class Sport
    {
        public readonly bool[] Exercises = new bool[6];
       
        public Sport(bool[] exercises)
        {
            Exercises = exercises;
        }
    }

    /// <summary>
    /// Логика взаимодействия для CalendarPage.xaml
    /// </summary>
    public partial class CalendarPage : Page
    {
        // настроить картинки

        public static Dictionary<DateTime, Sport> Accounting = null;
        public static DateTime SelectedDate = DateTime.Now;

        public CalendarPage()
        {
            InitializeComponent();

            datePicker.SelectedDate = SelectedDate;

            if (Accounting == null)
                Accounting = File.Exists("accounting.json")
                    ? JsonConvert.DeserializeObject<Dictionary<DateTime, Sport>>(File.ReadAllText("accounting.json"))
                    : new Dictionary<DateTime, Sport>();

            InitImagerInButton();
        }

        private void InitImagerInButton()
        {
            for (int i = 1; i <= 31; ++i)
            {
                var image = (Image)FindName("image" +  i);
                var date = datePicker.SelectedDate.Value.AddDays(-datePicker.SelectedDate.Value.Day + i).Date;
                if (!Accounting.ContainsKey(date))
                {
                    image.Source = new BitmapImage(new Uri("/UI/0.png", UriKind.Relative));
                    continue;
                }
                var sport = Accounting[date].Exercises;
                int indx = 0;
                for (int j = 0; j < sport.Length; ++j)
                    if (sport[j])
                    {
                        indx = j + 1;
                        break;
                    }
                var path = ("/UI/" + indx + ".png").ToString();
                image.Source = new BitmapImage(new Uri(path, UriKind.Relative));
            }
        }

        ~CalendarPage() 
        {
            // сериализация заметок
            File.WriteAllText("accounting.json", JsonConvert.SerializeObject(CalendarPage.Accounting));
        }

        public static string GetMonth(int month)
        {
            switch (month)
            {
                case 1:
                    return "January";
                case 2:
                    return "February";
                case 3:
                    return "March";
                case 4:
                    return "April";
                case 5:
                    return "May";
                case 6:
                    return "June";
                case 7:
                    return "Jule";
                case 8:
                    return "August";
                case 9:
                    return "September";
                case 10:
                    return "October";
                case 11:
                    return "November";
                case 12:
                    return "December";
                default:
                    throw new ArgumentException();
            }
        }

        void EnableDate()
        {
            var month = datePicker.SelectedDate.Value.Month;

            if (month == 2)
            {
                var year = datePicker.SelectedDate.Value.Year;
                button29.Visibility
                    = year % 4 == 0 && year % 100 != 0 || year % 400 == 0 // проверка на вискосность
                    ? Visibility.Visible
                    : Visibility.Hidden;
                button30.Visibility = Visibility.Hidden;
                button31.Visibility = Visibility.Hidden;
            }
            else if (month == 4 || month == 6 || month == 9 || month == 11)
            {
                button29.Visibility = Visibility.Visible;
                button30.Visibility = Visibility.Visible;
                button31.Visibility = Visibility.Hidden;
            }
            else
            {
                button29.Visibility = Visibility.Visible;
                button30.Visibility = Visibility.Visible;
                button31.Visibility = Visibility.Visible;
            }
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            datePicker.SelectedDate = datePicker.SelectedDate.Value.AddDays(-datePicker.SelectedDate.Value.Day + 1);
            datePicker.SelectedDate = datePicker.SelectedDate.Value.AddDays(0);
            NavigationService.Navigate(new ListPage());
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            datePicker.SelectedDate = datePicker.SelectedDate.Value.AddDays(-datePicker.SelectedDate.Value.Day + 1);
            datePicker.SelectedDate = datePicker.SelectedDate.Value.AddDays(1);
            NavigationService.Navigate(new ListPage());
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            datePicker.SelectedDate = datePicker.SelectedDate.Value.AddDays(-datePicker.SelectedDate.Value.Day + 1);
            datePicker.SelectedDate = datePicker.SelectedDate.Value.AddDays(2);
            NavigationService.Navigate(new ListPage());
        }

        private void button4_Click(object sender, RoutedEventArgs e)
        {
            datePicker.SelectedDate = datePicker.SelectedDate.Value.AddDays(-datePicker.SelectedDate.Value.Day + 1);
            datePicker.SelectedDate = datePicker.SelectedDate.Value.AddDays(3);
            NavigationService.Navigate(new ListPage());
        }

        private void button5_Click(object sender, RoutedEventArgs e)
        {
            datePicker.SelectedDate = datePicker.SelectedDate.Value.AddDays(-datePicker.SelectedDate.Value.Day + 1);
            datePicker.SelectedDate = datePicker.SelectedDate.Value.AddDays(4);
            NavigationService.Navigate(new ListPage());
        }

        private void button6_Click(object sender, RoutedEventArgs e)
        {
            datePicker.SelectedDate = datePicker.SelectedDate.Value.AddDays(-datePicker.SelectedDate.Value.Day + 1);
            datePicker.SelectedDate = datePicker.SelectedDate.Value.AddDays(5);
            NavigationService.Navigate(new ListPage());
        }

        private void button7_Click(object sender, RoutedEventArgs e)
        {
            datePicker.SelectedDate = datePicker.SelectedDate.Value.AddDays(-datePicker.SelectedDate.Value.Day + 1);
            datePicker.SelectedDate = datePicker.SelectedDate.Value.AddDays(6);
            NavigationService.Navigate(new ListPage());
        }

        private void button8_Click(object sender, RoutedEventArgs e)
        {
            datePicker.SelectedDate = datePicker.SelectedDate.Value.AddDays(-datePicker.SelectedDate.Value.Day + 1);
            datePicker.SelectedDate = datePicker.SelectedDate.Value.AddDays(7);
            NavigationService.Navigate(new ListPage());
        }

        private void button9_Click(object sender, RoutedEventArgs e)
        {
            datePicker.SelectedDate = datePicker.SelectedDate.Value.AddDays(-datePicker.SelectedDate.Value.Day + 1);
            datePicker.SelectedDate = datePicker.SelectedDate.Value.AddDays(8);
            NavigationService.Navigate(new ListPage());
        }

        private void button10_Click(object sender, RoutedEventArgs e)
        {
            datePicker.SelectedDate = datePicker.SelectedDate.Value.AddDays(-datePicker.SelectedDate.Value.Day + 1);
            datePicker.SelectedDate = datePicker.SelectedDate.Value.AddDays(9);
            NavigationService.Navigate(new ListPage());
        }

        private void button11_Click(object sender, RoutedEventArgs e)
        {
            datePicker.SelectedDate = datePicker.SelectedDate.Value.AddDays(-datePicker.SelectedDate.Value.Day + 1);
            datePicker.SelectedDate = datePicker.SelectedDate.Value.AddDays(10);
            NavigationService.Navigate(new ListPage());
        }

        private void button12_Click(object sender, RoutedEventArgs e)
        {
            datePicker.SelectedDate = datePicker.SelectedDate.Value.AddDays(-datePicker.SelectedDate.Value.Day + 1);
            datePicker.SelectedDate = datePicker.SelectedDate.Value.AddDays(11);
            NavigationService.Navigate(new ListPage());
        }

        private void button13_Click(object sender, RoutedEventArgs e)
        {
            datePicker.SelectedDate = datePicker.SelectedDate.Value.AddDays(-datePicker.SelectedDate.Value.Day + 1);
            datePicker.SelectedDate = datePicker.SelectedDate.Value.AddDays(12);
            NavigationService.Navigate(new ListPage());
        }

        private void button14_Click(object sender, RoutedEventArgs e)
        {
            datePicker.SelectedDate = datePicker.SelectedDate.Value.AddDays(-datePicker.SelectedDate.Value.Day + 1);
            datePicker.SelectedDate = datePicker.SelectedDate.Value.AddDays(13);
            NavigationService.Navigate(new ListPage());
        }

        private void button15_Click(object sender, RoutedEventArgs e)
        {
            datePicker.SelectedDate = datePicker.SelectedDate.Value.AddDays(-datePicker.SelectedDate.Value.Day + 1);
            datePicker.SelectedDate = datePicker.SelectedDate.Value.AddDays(14);
            NavigationService.Navigate(new ListPage());
        }

        private void button16_Click(object sender, RoutedEventArgs e)
        {
            datePicker.SelectedDate = datePicker.SelectedDate.Value.AddDays(-datePicker.SelectedDate.Value.Day + 1);
            datePicker.SelectedDate = datePicker.SelectedDate.Value.AddDays(15);
            NavigationService.Navigate(new ListPage());
        }

        private void button17_Click(object sender, RoutedEventArgs e)
        {
            datePicker.SelectedDate = datePicker.SelectedDate.Value.AddDays(-datePicker.SelectedDate.Value.Day + 1);
            datePicker.SelectedDate = datePicker.SelectedDate.Value.AddDays(16);
            NavigationService.Navigate(new ListPage());
        }

        private void button18_Click(object sender, RoutedEventArgs e)
        {
            datePicker.SelectedDate = datePicker.SelectedDate.Value.AddDays(-datePicker.SelectedDate.Value.Day + 1);
            datePicker.SelectedDate = datePicker.SelectedDate.Value.AddDays(17);
            NavigationService.Navigate(new ListPage());
        }

        private void button19_Click(object sender, RoutedEventArgs e)
        {
            datePicker.SelectedDate = datePicker.SelectedDate.Value.AddDays(-datePicker.SelectedDate.Value.Day + 1);
            datePicker.SelectedDate = datePicker.SelectedDate.Value.AddDays(18);
            NavigationService.Navigate(new ListPage());
        }

        private void button20_Click(object sender, RoutedEventArgs e)
        {
            datePicker.SelectedDate = datePicker.SelectedDate.Value.AddDays(-datePicker.SelectedDate.Value.Day + 1);
            datePicker.SelectedDate = datePicker.SelectedDate.Value.AddDays(19);
            NavigationService.Navigate(new ListPage());
        }

        private void button21_Click(object sender, RoutedEventArgs e)
        {
            datePicker.SelectedDate = datePicker.SelectedDate.Value.AddDays(-datePicker.SelectedDate.Value.Day + 1);
            datePicker.SelectedDate = datePicker.SelectedDate.Value.AddDays(20);
            NavigationService.Navigate(new ListPage());
        }

        private void button22_Click(object sender, RoutedEventArgs e)
        {
            datePicker.SelectedDate = datePicker.SelectedDate.Value.AddDays(-datePicker.SelectedDate.Value.Day + 1);
            datePicker.SelectedDate = datePicker.SelectedDate.Value.AddDays(21);
            NavigationService.Navigate(new ListPage());
        }

        private void button23_Click(object sender, RoutedEventArgs e)
        {
            datePicker.SelectedDate = datePicker.SelectedDate.Value.AddDays(-datePicker.SelectedDate.Value.Day + 1);
            datePicker.SelectedDate = datePicker.SelectedDate.Value.AddDays(22);
            NavigationService.Navigate(new ListPage());
        }

        private void button24_Click(object sender, RoutedEventArgs e)
        {
            datePicker.SelectedDate = datePicker.SelectedDate.Value.AddDays(-datePicker.SelectedDate.Value.Day + 1);
            datePicker.SelectedDate = datePicker.SelectedDate.Value.AddDays(23);
            NavigationService.Navigate(new ListPage());
        }

        private void button25_Click(object sender, RoutedEventArgs e)
        {
            datePicker.SelectedDate = datePicker.SelectedDate.Value.AddDays(-datePicker.SelectedDate.Value.Day + 1);
            datePicker.SelectedDate = datePicker.SelectedDate.Value.AddDays(24);
            NavigationService.Navigate(new ListPage());
        }

        private void button26_Click(object sender, RoutedEventArgs e)
        {
            datePicker.SelectedDate = datePicker.SelectedDate.Value.AddDays(-datePicker.SelectedDate.Value.Day + 1);
            datePicker.SelectedDate = datePicker.SelectedDate.Value.AddDays(25);
            NavigationService.Navigate(new ListPage());
        }

        private void button27_Click(object sender, RoutedEventArgs e)
        {
            datePicker.SelectedDate = datePicker.SelectedDate.Value.AddDays(-datePicker.SelectedDate.Value.Day + 1);
            datePicker.SelectedDate = datePicker.SelectedDate.Value.AddDays(26);
            NavigationService.Navigate(new ListPage());
        }

        private void button28_Click(object sender, RoutedEventArgs e)
        {
            datePicker.SelectedDate = datePicker.SelectedDate.Value.AddDays(-datePicker.SelectedDate.Value.Day + 1);
            datePicker.SelectedDate = datePicker.SelectedDate.Value.AddDays(27);
            NavigationService.Navigate(new ListPage());
        }

        private void button29_Click(object sender, RoutedEventArgs e)
        {
            datePicker.SelectedDate = datePicker.SelectedDate.Value.AddDays(-datePicker.SelectedDate.Value.Day);
            datePicker.SelectedDate = datePicker.SelectedDate.Value.AddDays(28);
            NavigationService.Navigate(new ListPage());
        }

        private void button30_Click(object sender, RoutedEventArgs e)
        {
            datePicker.SelectedDate = datePicker.SelectedDate.Value.AddDays(-datePicker.SelectedDate.Value.Day);
            datePicker.SelectedDate = datePicker.SelectedDate.Value.AddDays(29);
            NavigationService.Navigate(new ListPage());
        }

        private void button31_Click(object sender, RoutedEventArgs e)
        {
            datePicker.SelectedDate = datePicker.SelectedDate.Value.AddDays(-datePicker.SelectedDate.Value.Day);
            datePicker.SelectedDate = datePicker.SelectedDate.Value.AddDays(30);
            NavigationService.Navigate(new ListPage());
        }

        private void buttonNext_Click(object sender, RoutedEventArgs e)
        {
            datePicker.SelectedDate = datePicker.SelectedDate.Value.AddMonths(1);
            InitImagerInButton();
        }

        private void buttonPrev_Click(object sender, RoutedEventArgs e)
        {
            datePicker.SelectedDate = datePicker.SelectedDate.Value.AddMonths(-1);
            InitImagerInButton();
        }

        private void datePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            SelectedDate = datePicker.SelectedDate.Value.Date;

            labelDate.Content = GetMonth(datePicker.SelectedDate.Value.Month) + " " + datePicker.SelectedDate.Value.Year;

            EnableDate();
        }

        private void buttonDelete_Click(object sender, RoutedEventArgs e)
        {
            Accounting.Clear();
        }
    }
}
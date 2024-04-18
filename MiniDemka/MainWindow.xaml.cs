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
using MiniDemka.Models;

namespace MiniDemka
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ApplicationContext app = new ApplicationContext();
        List<Events> events;
        List<Events> eventsSort;
        List<Events> eventsSearch;
        List<City> cities;
        int srt = -1;
        int srtClear = 0;
        public MainWindow()
        {
            InitializeComponent();
            Output();
        }

        public void Output()
        {
            events = app.Events.ToList();
            cities = app.City.ToList();
            int? cId;

            for (int i = 0; i < events.Count; i++) 
            {
                cId = events[i].CityID;
                events[i].CityName = cities.FirstOrDefault(xe => xe.ID == cId).Name;
            }
            eventsSort = app.Events.ToList();
            eventsSearch = app.Events.ToList();
            evList.ItemsSource = events;
        }

        private void buttonOrderBy_Click(object sender, RoutedEventArgs e)
        {
            srt = 0;
            Func();
        }

        private void buttonOrderByDesc_Click(object sender, RoutedEventArgs e)
        {
            srt = 1;
            Func();
            
        }

        private void searchTxb_TextChanged(object sender, TextChangedEventArgs e)
        {
            Func();
        }

        public void Func()
        {
            if (srtClear == 1)
            {
                Output();
                searchTxb.Text = "";
            }
            else
            {
                var eventsWithAll = events;
                if (searchTxb.Text != "")
                {
                    eventsWithAll = eventsWithAll.Where(x => x.Event.Contains(searchTxb.Text)).ToList();
                    evList.ItemsSource = eventsWithAll;
                }
                else
                {
                    evList.ItemsSource = events;
                    switch (srt)
                    {
                        case 0:
                            events = events.OrderBy(xe => xe.Date).ToList();
                            evList.ItemsSource = events;
                            break;
                        case 1:
                            events = events.OrderByDescending(xe => xe.Date).ToList();
                            evList.ItemsSource = events;
                            break;
                    }
                }
                switch (srt)
                {
                    case 0:
                        eventsWithAll = eventsWithAll.OrderBy(xe => xe.Date).ToList();
                        evList.ItemsSource = eventsWithAll;
                        break;
                    case 1:
                        eventsWithAll = eventsWithAll.OrderByDescending(xe => xe.Date).ToList();
                        evList.ItemsSource = eventsWithAll;
                        break;
                    default:
                        break;
                }
            }

            
        }

        private void cleadrSrtFlt_Click(object sender, RoutedEventArgs e)
        {
            srtClear = 1;
            Func();
            srtClear = 0;
        }

        private void redButton_Click(object sender, RoutedEventArgs e)
        {
            Button b = sender as Button;
            int t = (int)b.Tag;
            Add a = new Add("red", t);
            a.ShowDialog();
            evList.ItemsSource = null;
            Output();
            MainWindow m = new MainWindow();
            m.Show();
            this.Close();
        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult messageBoxResult = MessageBox.Show("Вы действительно хотите удалить мероприятие?","Уведомление", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                Button b = sender as Button;
                int t = (int)b.Tag;
                var ee = app.Events.FirstOrDefault(x => x.ID == t);
                app.Events.Remove(ee);
                app.SaveChanges();
                MessageBox.Show("Мероприятие удалено", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                evList.ItemsSource = null;
                Output();
                MainWindow m = new MainWindow();
                m.Show();
                this.Close();

            }
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            Add a = new Add("add", 0);
            a.ShowDialog();
            evList.ItemsSource = null;
            Output();
        }
    }
}

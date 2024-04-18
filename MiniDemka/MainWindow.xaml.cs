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
            evList.ItemsSource = events;
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
            Add a = new Add();
            a.ShowDialog();
            evList.ItemsSource = null;
            Output();
        }
    }
}

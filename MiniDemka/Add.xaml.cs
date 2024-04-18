using MiniDemka.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MiniDemka
{
    /// <summary>
    /// Логика взаимодействия для Add.xaml
    /// </summary>
    public partial class Add : Window
    {
        ApplicationContext app = new ApplicationContext();
        List<Events> events;
        List<City> cities;
        public string window;
        public int evID;
        public Add(string w, int id)
        {
            InitializeComponent();
            window = w;
            evID = id;
            if (window == "red")
            {
                Output();
            }
            else if (window == "add")
            {
                Output_Mini();
            }
        }

        public void Output()
        {
            add.Content = "Применить";
            var events = app.Events.Where(x=> x.ID == evID).ToList();
            var ev = app.Events.FirstOrDefault(x => x.ID == evID);
            int ccId = Convert.ToInt32(ev.CityID);
            var cities = app.City.ToList();
            int? cId;
            for (int i = 0; i < events.Count; i++)
            {
                cId = events[i].ID;
                events[i].CityName = cities.FirstOrDefault(xe => xe.ID == cId).Name;
            }
            comboCity.ItemsSource = cities.Select(x => x.Name);
            comboCity.SelectedIndex = ccId - 1;
            dateTxb.Text = events[0].Date.ToString();
            nameTxb.Text = events[0].Event;
            daysTxb.Text = events[0].Days.ToString();
        }

        public void Output_Mini()
        {
            var cities = app.City.ToList();
            add.Content = "Добавить";
            comboCity.ItemsSource = cities.Select(x => x.Name);
        }

        private void add_Click(object sender, RoutedEventArgs e)
        {
            if (window == "red")
            {
                if (nameTxb.Text != "" || dateTxb.Text != "" || daysTxb.Text != "")
                {
                    int? ei = evID;
                    var ev = app.Events.Where(x => x.ID == ei).ToList();
                    int? d = Convert.ToInt32(daysTxb.Text);
                    DateTime dt = DateTime.Parse(dateTxb.Text);
                    if (dt > DateTime.Now)
                    {
                        ev[0].Event = nameTxb.Text;
                        ev[0].Date = dt;
                        ev[0].Days = d;
                        ev[0].CityID = comboCity.SelectedIndex + 1;
                        app.SaveChanges();
                        MessageBox.Show("Изменения сохранены", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Выберите верную дату", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);

                    }
                }
                else
                {
                    MessageBox.Show("Заполните все поля", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }

            }
            else if (window == "add")
            {
                if (nameTxb.Text != "" || dateTxb.Text != "" || daysTxb.Text != "" || dateTxb != null)
                {
                    int? d = Convert.ToInt32(daysTxb.Text);
                    DateTime dt = DateTime.Parse(dateTxb.Text);
                    if (dt > DateTime.Now)
                    {
                        Events newItem = new Events
                        {
                            Event = nameTxb.Text,
                            Date = dt,
                            Days = d,
                            CityID = comboCity.SelectedIndex + 1
                        };
                        app.Events.Add(newItem);
                        app.SaveChanges();
                        MessageBox.Show("Мероприятие додбавлено", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Выберите верную дату", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);

                    }

                }
                else
                {
                    MessageBox.Show("Заполните все поля", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
    }
}

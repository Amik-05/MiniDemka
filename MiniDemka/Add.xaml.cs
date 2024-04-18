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
        public Add()
        {
            InitializeComponent();
            Output_Mini();
        }

        public void Output_Mini()
        {
            var cities = app.City.ToList();
            add.Content = "Добавить";
            comboCity.ItemsSource = cities.Select(x => x.Name);
        }

        private void add_Click(object sender, RoutedEventArgs e)
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

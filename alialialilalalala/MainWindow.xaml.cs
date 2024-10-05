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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace alialialilalalala
{
    public partial class MainWindow : Window
    {
        private ObservableCollection<PhotoService> _services;

        public class PhotoService
        {
            public string Name { get; set; }
            public decimal Price { get; set; }
            public string Description { get; set; }
            public string ImagePath { get; set; }

            public override string ToString()
            {
                return Name; // Возвращаем имя услуги
            }
        }

        public MainWindow()
        {
            InitializeComponent();
            LoadServices();
        }

        private void LoadServices()
        {
            _services = new ObservableCollection<PhotoService>
            {
                new PhotoService { Name = "Печать фотографий", Price = 100.00m, Description = "Печать в различных форматах", ImagePath = @"C:\Users\alialialilalala\Downloads\печатьфото.jpg"},
                new PhotoService { Name = "Проявление пленок", Price = 150.00m, Description = "Проявление ч/б и цветных пленок", ImagePath = @"C:\Users\alialialilalala\Downloads\проявление.jpg"},
                new PhotoService { Name = "Художественное фото", Price = 5000.00m, Description = "Профессиональная съемка", ImagePath = @"C:\Users\alialialilalala\Downloads\худфото.jpg"},
            };

            listView.ItemsSource = _services;
            serviceComboBox.ItemsSource = _services;
        }

        private void ListView_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (listView.SelectedItem is PhotoService selectedService)
            {
                photoImage.Source = new BitmapImage(new Uri(selectedService.ImagePath));
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            tabControl1.SelectedIndex = 0;
        }

        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            string name = nameTextBox.Text;
            string contact = contactTextBox.Text;

            if (string.IsNullOrEmpty(name)  string.IsNullOrEmpty(contact)  !(serviceComboBox.SelectedItem is PhotoService photoService))
            {
                MessageBox.Show("Пожалуйста, заполните все поля.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            MessageBox.Show($"Заявка на услугу '{photoService.Name}' успешно отправлена!\nИмя: {name}\nКонтакт: {contact}", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);

            nameTextBox.Clear();
            contactTextBox.Clear();
            serviceComboBox.SelectedIndex = -1;
        }
    }
}

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
            public string ImagePath { get; set; } // Путь к изображению
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
    }

}
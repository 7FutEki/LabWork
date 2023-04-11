using LabWork.Forms;
using LabWork.Models;
using System;
using System.Collections.Concurrent;
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

namespace LabWork
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<Product> TapProduct { get; set; }
        public Product Product { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            TapProduct = new();
            DataContext = this;

        }




        private void btn_add_Click(object sender, RoutedEventArgs e)
        {
            
            Forms.Window_Add window_Add = new Forms.Window_Add();
            window_Add.ShowDialog();
            TapProduct.Add(window_Add.Product);
        }

        private void btn_edit_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btn_dlt_Click(object sender, RoutedEventArgs e)
        {
            if (Product == null)
            {
                return;
            }
            Window_Add window = new Window_Add();
            MessageBoxResult messageBoxResult = MessageBox.Show("Вы уверены?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                TapProduct.Remove(Product);
            }
        }
    }
}

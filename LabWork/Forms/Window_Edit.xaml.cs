using LabWork.Models;
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
using System.Windows.Shapes;

namespace LabWork.Forms
{
    /// <summary>
    /// Логика взаимодействия для Window_Edit.xaml
    /// </summary>
    public partial class Window_Edit : Window
    {
        public Product Product { get; set; }

        public Window_Edit(Product product)
        {
            InitializeComponent();
            Product = product;
            DataContext = Product;
        }

        private void btn_add_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            Close();
        }

        private void btn_madeQr_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}

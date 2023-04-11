using LabWork.Models;
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
using System.Windows.Shapes;

namespace LabWork.Forms
{
    /// <summary>
    /// Логика взаимодействия для Window_Add.xaml
    /// </summary>
    public partial class Window_Add : Window
    {
        public Product Product { get; set; }
        public Window_Add()
        {
            InitializeComponent();
            Product = new Product();
            DataContext = Product;
            Product.Id = Guid.NewGuid();
        }
        
        private void btn_add_Click(object sender, RoutedEventArgs e)
        {
            
            Metods.Metods.AddProduct(Product.Id, Product.Name, Product.Price, Product.Options);
            this.Close();
        }


        



        private void btn_madeQr_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}

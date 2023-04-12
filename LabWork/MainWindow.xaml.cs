using LabWork.Forms;
using LabWork.Models;
using Microsoft.EntityFrameworkCore;
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
            this.Loaded += Sqlite_Loaded;
        }


        private void Sqlite_Loaded(object sender, RoutedEventArgs e)
        {
            ApplicationContext db= new ApplicationContext();
            db.Database.Migrate();
            List<Product> products = db.Products.ToList();
            tapProduct.ItemsSource = products;
        }



        private void btn_add_Click(object sender, RoutedEventArgs e)
        {
            
            Forms.Window_Add window_Add = new Forms.Window_Add();
            Close();
            window_Add.ShowDialog();
        }

        private void btn_edit_Click(object sender, RoutedEventArgs e)
        { 
            var product = tapProduct.SelectedItem as Product;
            
            if (new Forms.Window_Edit(product).ShowDialog() == true)
            {
                using (var context = new ApplicationContext())
                {
                    context.Entry(product).State = EntityState.Modified;
                    context.SaveChanges();
                    
                }
                tapProduct.Items.Refresh();
            }

        }

        private void btn_dlt_Click(object sender, RoutedEventArgs e)
        {
            if (Product != null)
            {
            MessageBoxResult messageBoxResult = MessageBox.Show("Вы уверены?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                var product = tapProduct.SelectedItem as Product;
                using (var context = new ApplicationContext())
                {
                    context.Products.Remove(product);
                    context.SaveChanges();
                    tapProduct.ItemsSource = context.Products.ToList();
                }
            }
                
            }
        }
    }
}

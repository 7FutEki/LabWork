using LabWork.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;
using System.Xml.XPath;

namespace LabWork.Metods
{ 
    public class Metods
    {
        public static string AddProduct(Guid Id, string name, double price, string options)
        {
            
            string result = "Уже существует";
            using(ApplicationContext db = new ApplicationContext())
            {
                db.Database.Migrate();
                bool check = db.Products.Any(el => el.Name == name && el.Price == price && el.Options == options); 
                if (!check) 
                {
                    Product newproduct = new Product
                    {
                        Name = name,
                        Price = price,
                        Options = options,
                        Id = Guid.NewGuid()
                    };
                    db.Products.Add(newproduct);
                    db.SaveChanges();
                    result = "Сделано";
                }
                return result;
            }
        }
    }
}

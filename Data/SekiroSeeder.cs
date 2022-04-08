using Microsoft.AspNetCore.Hosting;
using SekiroApp.Data.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace SekiroApp.Data
{
    public class SekiroSeeder
    {
        private readonly SekiroContext _context;
        private readonly IWebHostEnvironment _environment;

        public SekiroSeeder(SekiroContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        public void Seed()
        {
            _context.Database.EnsureCreated();

            if (!_context.Products.Any())
            {
                // need to create sample data
                var filePath = Path.Combine(_environment.ContentRootPath, "Data/art.json");
                var json = File.ReadAllText(filePath);
                var products = JsonSerializer.Deserialize<IEnumerable<Product>>(json);

                _context.Products.AddRange(products);

                var order = _context.Orders.Where(o => o.Id == 1).FirstOrDefault();
                if(order != null)
                {
                    order.Items = new List<OrderItem>()
                    {
                        new OrderItem()
                        {
                            Product = products.First(),
                            Quantity = 5,
                            UnitPrice = products.First().Price
                        }
                    };
                }

                /*var order = new Order()
                {
                    OrderDate = DateTime.Today,
                    OrderNumber = "10001",
                    Items = new List<OrderItem>()
                    {
                        new OrderItem()
                        {
                            Product = products.First(),
                            Quantity = 1,
                            UnitPrice = products.First().Price
                        }
                    }
                };

                _context.Orders.Add(order);*/

                _context.SaveChanges();
            }
        }
    }
}

using SekiroApp.Data.Entities;
using System.Collections.Generic;

namespace SekiroApp.Data
{
    public interface ISekiroRepository
    {
        IEnumerable<Product> GetAllProducts();
        IEnumerable<Product> GetProductsByCategory(string category);
        bool SaveAll();
    }
}
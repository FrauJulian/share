using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ
{
    public class Product
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; }
        public List<int> Review { get; set; }
        public int Amount { get; set; }

        public Product(int id, string name, string category, decimal price, List<int> review, int amount)
        {
            ID = id;
            Name = name;
            Category = category;
            Price = price;
            Review = review;
            Amount = amount;
        }
    }
}

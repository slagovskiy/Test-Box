using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace teach02.Models
{
    public class Product
    {
        public string Name { get; set; }
        public decimal? Price { get; set; }
        public Product Related { get; set; }

        public static Product[] GetProducts() {
            Product car = new Product
            {
                Name = "Mersedes 600",
                Price = 100M
            };
            Product jacket = new Product
            {
                Name = "Malinovii",
                Price = 50M
            };

            car.Related = jacket;

            return new Product[] { car, jacket, null };
        }
    }
}

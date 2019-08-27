using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace teach04.Models
{
    public class FakeProductRepository: IProductRepository
    {
        public IQueryable<Product> Products => new List<Product>
        {
            new Product { Name = "Football", Price = 25 },
            new Product { Name = "Surfboard", Price = 179 },
            new Product { Name = "Running shoes", Price = 300 }
        }.AsQueryable<Product>();
    }
}

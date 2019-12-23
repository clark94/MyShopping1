using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Caching;
using MyShop.Core.Models;

namespace MyShop.DataAcess.InMemory
{
    public class ProductRepository
    {
        ObjectCache cache = MemoryCache.Default;
        List<Product> products = new List<Product>();

        public ProductRepository()
        {
            products = cache["products"] as List<Product>;

            if(products == null)
            {
                products = new List<Product>();
            }
        }

        public void Commit()
        {
            cache["products"] = products;
        }

        public void Insert(Product p)
        {
            products.Add(p);
        }

        public void Update(Product product)
        {
            Product ProductToUpdate = products.Find(x => x.Id == product.Id);

            if (ProductToUpdate != null)
            {
                ProductToUpdate = product;

            }

            else
            {
                throw new Exception("Product not found");
            }
        }

        public Product Find(string Id)
        {
            Product  product = products.Find(x => x.Id == Id);

            if (product != null)
            {
                return product;

            }

            else
            {
                throw new Exception("Product not found");
            }
        }

        public IQueryable<Product> Collection()
        {
            return products.AsQueryable();
        }

        public void Delete(string Id) 
        {
            Product ProductToDelete = products.Find(x => x.Id == Id);

            if (ProductToDelete != null)
            {
                products.Remove(ProductToDelete);

            }

            else
            {
                throw new Exception("Product not found");
            }
        }


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Caching;
using MyShop.Core.Models;

namespace MyShop.DataAcess.InMemory
{
    public class ProductCategoryRepository
    {
        ObjectCache cache = MemoryCache.Default;
        List<ProductCategory> productCategories = new List<ProductCategory>();

        public ProductCategoryRepository()
        {
            productCategories = cache["productCategories"] as List<ProductCategory>;

            if (productCategories == null)
            {
                productCategories = new List<ProductCategory>();
            }
        }

        public void Commit()
        {
            cache["productCategories"] = productCategories;
        }

        public void Insert(ProductCategory p)
        {
            productCategories.Add(p);
        }

        public void Update(ProductCategory productCategories)
        {
            ProductCategory ProductToUpdate = this.productCategories.Find(x => x.Id == productCategories.Id);

            if (ProductToUpdate != null)
            {
                ProductToUpdate = productCategories;

            }

            else
            {
                throw new Exception("Product not found");
            }
        }

        public ProductCategory Find(string Id)
        {
            ProductCategory product = productCategories.Find(x => x.Id == Id);

            if (product != null)
            {
                return product;

            }

            else
            {
                throw new Exception("Product not found");
            }
        }

        public IQueryable<ProductCategory> Collection()
        {
            return productCategories.AsQueryable();
        }

        public void Delete(string Id)
        {
            ProductCategory ProductToDelete = productCategories.Find(x => x.Id == Id);

            if (ProductToDelete != null)
            {
                productCategories.Remove(ProductToDelete);

            }

            else
            {
                throw new Exception("Product not found");
            }
        }

    }
}

using MyShop.Core.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.DataAcess.SQL
{
    public class DataContext : DbContext
    {

     
        //Crio pois assim ele vai até meu WebConfig e conecta com a base de Dados.
        public DataContext() : base("DefaultConnection")
        {
           
        }

        //Aqui referencio os modelos a qual eu quero trabalhar No caso Produto e Produto Categoria
        public DbSet<Product> Products { get; set;}
        public DbSet<ProductCategory> ProductCategories { get; set; }




    }
}

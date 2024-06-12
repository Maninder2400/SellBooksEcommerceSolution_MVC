using SellBooks.DataAccess.Data;
using SellBooks.DataAccess.Repository.IRepository;
using SellBooks.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SellBooks.DataAccess.Repository
{
    public class ProductRepository :Repository<Product>, IProductRepository
    {
        private readonly ApplicationDbContext _db;

        public ProductRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Product product)
        {
            var productFromDb = _db.Products.FirstOrDefault( u => u.Id == product.Id);  
            if (productFromDb != null)
            {
                 productFromDb.Title =  product.Title;
                productFromDb.Price = product.Price;
                productFromDb.Description = product.Description;
                 productFromDb.CategoryId =  product.CategoryId;
                productFromDb.ISBN = product.ISBN;
                productFromDb.Author = product.Author;
                productFromDb.Price100 = product.Price100;
                productFromDb.Price50 = product.Price50;
                productFromDb.ListPrice = product.ListPrice;    
                if(productFromDb.ImageUrl != product.ImageUrl)
                {
                    productFromDb.ImageUrl = product.ImageUrl;
                }
            }
        }
    }
}

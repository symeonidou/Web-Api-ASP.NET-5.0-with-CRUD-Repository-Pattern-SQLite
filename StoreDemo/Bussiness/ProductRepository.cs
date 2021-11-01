using StoreDemo.AppDbContext;
using StoreDemo.Entities;
using StoreDemo.Infrastructure;
using StoreDemo.ViewModel;
using System.Collections.Generic;
using System.Linq;

namespace StoreDemo.Bussiness
{
    //Inherited from IProductRepo

    public class ProductRepository : IProductRepository

    {
        private readonly DataDbContext _context;

        public ProductRepository(DataDbContext context)
        {
            _context = context;
        }

        //CRUD 

        //Read
        public IEnumerable<Product> GetAll()
        {
            return _context.Products.ToList();
        }

        public Product GetById(int id)
        {
            return _context.Products.FirstOrDefault(c => c.Id == id);
        }

        //Create
        public void Create(CreateProductVm productVm)
        {
            Product product = new Product()
            {
                Brand = productVm.Brand,
                Color = productVm.Color,
                Description = productVm.Description,
                Price = productVm.Price,
                CategoryId = productVm.CategoryId
            };  
            _context.Products.Add(product);
            _context.SaveChanges();
        }

        //Update
        public void Update(UpdateProductVm productVm)
        {
            Product product = new Product()
            {
                Id = productVm.Id,
                Brand = productVm.Brand,
                Color = productVm.Color,
                Description = productVm.Description,
                Price = productVm.Price,
                CategoryId = productVm.CategoryId
            };
            _context.Products.Update(product);
            _context.SaveChanges();
        }

        //Delete
        public void Delete(Product product)
        {
            _context.Products.Remove(product);
            _context.SaveChanges();
        }
    }
}

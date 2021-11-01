using StoreDemo.AppDbContext;
using StoreDemo.Entities;
using StoreDemo.Infrastructure;
using StoreDemo.ViewModel;
using System.Collections.Generic;
using System.Linq;

namespace StoreDemo.Bussiness
{

    //Inherited from ICategoryRepo

    public class CategoryRepository : ICategoryRepository
    {
        private readonly DataDbContext _context;
        public CategoryRepository(DataDbContext context)
        {
            _context = context;
        }

        //CRUD Actions

        //Read
        public IEnumerable<Category> GetAll()
        {
            return _context.Categories.ToList();
        }

        public Category GetById(int id)
        {
            return _context.Categories.FirstOrDefault(c => c.CategoryId == id);
        }

        //Create
        public void Create(CreateCategoryVm categoryVm)
        {
            Category category = new Category()
            {
                Name = categoryVm.Name
            };

            _context.Categories.Add(category);

            _context.SaveChanges();
        }
        //Update
        public void Update(UpdateCategoryVm categoryVm)
        {
            Category category = new Category()
            {
                CategoryId = categoryVm.CategoryId,
                Name = categoryVm.Name
            };

            _context.Categories.Update(category);

            _context.SaveChanges();
        }
        //Delete
        public void Delete(Category category)
        {
            _context.Categories.Remove(category);

            _context.SaveChanges();
        }
    }
}

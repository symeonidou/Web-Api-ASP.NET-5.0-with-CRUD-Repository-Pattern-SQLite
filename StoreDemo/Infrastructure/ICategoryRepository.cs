using StoreDemo.Entities;
using StoreDemo.ViewModel;
using System.Collections.Generic;

namespace StoreDemo.Infrastructure
{
    //Repository interface that defines common functions and the inplementation methods according to our classes

    public interface ICategoryRepository
    {
            public void Create(CreateCategoryVm categoryVm);
            public void Update(UpdateCategoryVm categoryVm);
            public IEnumerable<Category> GetAll();
            public Category GetById(int id);
            public void Delete(Category product);
    }
}

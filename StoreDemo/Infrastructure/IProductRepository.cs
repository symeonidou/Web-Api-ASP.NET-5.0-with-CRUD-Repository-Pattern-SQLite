using StoreDemo.Entities;
using StoreDemo.ViewModel;
using System.Collections.Generic;

namespace StoreDemo.Infrastructure
{
    //Repository interface that defines common functions and the inplementation methods according to our classes

    public interface IProductRepository
    {
            public void Create(CreateProductVm productVm);
            public void Update(UpdateProductVm productVm);
            public IEnumerable<Product> GetAll();
            public Product GetById(int id);
            public void Delete(Product productVm);
    }
}

using Microsoft.AspNetCore.Mvc;
using StoreDemo.Entities;
using StoreDemo.Infrastructure;
using StoreDemo.ViewModel;
using System.Collections.Generic;

namespace StoreDemo.Controllers

{
    [ApiController]
    public class ProductController : Controller
        {
        private readonly IProductRepository _repository;

        public ProductController(IProductRepository repository)
            {
                _repository = repository;
            }

        // Each method uses repository to call CRUD actions 


        [HttpGet("Products")]
        public IActionResult GetProducts()
            {
                IEnumerable<Product> products = _repository.GetAll();
                return Ok(products);
            }

        [HttpGet("Product/{id}")]
        public IActionResult GetProduct(int id)
            {
                Product product = _repository.GetById(id);

            if (product == null)
            {
                return NotFound("Try Again!");
            }
                return Ok(product);
            }

        [HttpPost("Product")]
        public IActionResult Post([FromBody] CreateProductVm productVm)
            {
            if (productVm == null)
            {
                return BadRequest("Try Again!");
            }
            
            _repository.Create(productVm);

                return Ok(productVm);
            }

        [HttpPut("Product/{id}")]
        public IActionResult Put(int id, [FromBody] UpdateProductVm productVm)
        {
            if (productVm == null)
            {
                return BadRequest("Try Again!");
            }

            if (id != productVm.Id)
            {
                return NotFound("Try Again!");
            }

            _repository.Update(productVm);

            return Ok(productVm);
        }

        [HttpDelete("Product/{id}")]
        public IActionResult Delete(int id)
        {
            Product product = _repository.GetById(id);

            if (product == null)
            {
                return BadRequest("Try Again!");
            }

            _repository.Delete(product);

            return Ok(product);
        }
    }
}

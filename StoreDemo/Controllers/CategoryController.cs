using Microsoft.AspNetCore.Mvc;
using StoreDemo.Entities;
using StoreDemo.Infrastructure;
using StoreDemo.ViewModel;
using System.Collections.Generic;

namespace StoreDemo.Controllers
{
    [ApiController]
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _repository;

        public CategoryController(ICategoryRepository repository)
        {
            _repository = repository;
        }

        // Each method uses repository to call CRUD actions 

        [HttpGet("Categories")]
        public IActionResult GetCategories()
        {
            IEnumerable<Category> categories = _repository.GetAll();

            return Ok(categories);
        }

        [HttpGet("Category/{id}")]
        public IActionResult Getcategory(int id)
        {
            Category category = _repository.GetById(id);

            if (category == null)
            {
                return NotFound("Try Again!");
            }
            return Ok(category);
        }

        [HttpPost("Category")]
        public IActionResult Post([FromBody] CreateCategoryVm categoryVm)
        {
            if (categoryVm == null)
            {
                return BadRequest("Try Again!");
            }
            _repository.Create(categoryVm);

            return Ok(categoryVm);
        }

        [HttpPut("Category/{id}")]
        public IActionResult Put(int id, [FromBody] UpdateCategoryVm categoryVm)
        {
            if (categoryVm == null)
            {
                return BadRequest("Try Again!");
            }

            if (id != categoryVm.CategoryId)
            {
                return NotFound("Try Again!");
            }

            _repository.Update(categoryVm);
            return Ok(categoryVm);
        }

        [HttpDelete("Category/{id}")]
        public IActionResult Delete(int id)
        {
            Category category = _repository.GetById(id);

            if (category == null)
            {
                return BadRequest("Try Again!");
            }
            _repository.Delete(category);

            return Ok(category);
        }
    }
}

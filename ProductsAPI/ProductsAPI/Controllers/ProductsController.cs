using Microsoft.AspNetCore.Mvc;
using ProductsAPI.Models;
using ProductsAPI.Repositories.Interfaces;

namespace ProductsAPI.Controllers
{
    /// <summary>
    /// Controller for managing products via RESTful API.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : Controller
    {
        private readonly IProductRepository _repository;

        public ProductsController(IProductRepository repository)
        {
            _repository = repository;
        }

        // GET: api/products
        [HttpGet]
        public IActionResult GetAll() => Ok(_repository.GetAll());

        // GET: api/products/{id}
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var product = _repository.GetById(id);
            if (product == null) return NotFound();
            return Ok(product);
        }

        // POST: api/products
        [HttpPost]
        public IActionResult Create([FromBody] Product product)
        {
            var created = _repository.Add(product);
            return CreatedAtAction(nameof(GetById), new { id = created.ProductID }, created);
        }

        // PUT: api/products/{id}
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Product product)
        {
            var existing = _repository.GetById(id);
            if (existing == null) return NotFound();

            product.ProductID = id;
            _repository.Update(product);
            return NoContent();
        }

        // DELETE: api/products/{id}
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var existing = _repository.GetById(id);
            if (existing == null) return NotFound();

            _repository.Delete(id);
            return NoContent();
        }
    }
}

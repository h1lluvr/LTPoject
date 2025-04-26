using LT.Application.DTOs;
using LT.Application.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LT.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetAll()
        {
            var products = await _productService.GetAllAsync();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDto>> GetById(int id)
        {
            var product = await _productService.GetByIdAsync(id);
            if (product is null)
                return NotFound();

            return Ok(product);
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] ProductCreateDto dto)
        {
            var newId = await _productService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = newId }, null);
        }

        // TO DO: Edit and Delete actions
        #region answer
        [HttpPut("{id}")]
        public async Task<ActionResult<ProductDto>> Update(int id, [FromBody] ProductUpdateDto dto)
        {
            if (dto == null || id != dto.Id)
                return BadRequest("El ID de la URL debe coincidir con el del cuerpo.");

            var updated = await _productService.UpdateAsync(dto);
            if (updated is null)
                return NotFound($"No existe ningún producto con Id = {id}.");

            return Ok(updated);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var success = await _productService.DeleteAsync(id);
            if (!success)
                return NotFound($"No existe ningún producto con Id = {id}.");

            // 204 No Content = borrado correcto, no devolvemos cuerpo
            return NoContent();
        }
        #endregion
    }
}
using AutoMapper;
using FoodDiary.Services.Abstract;
using FoodDiary.Services.Models;
using FoodDiary.WebAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace FoodDiary.WebAPI.Controllers
{
    /// <summary>
    /// Products endpoints
    /// </summary>
    [ProducesResponseType(200)]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService productService;
        private readonly IMapper mapper;

        /// <summary>
        /// Products controller
        /// </summary>
        public ProductsController(IProductService productService, IMapper mapper)
        {
            this.productService = productService;
            this.mapper = mapper;
        }
        /// <summary>
        /// Get Products by pages
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetProducts([FromQuery] int limit = 20, [FromQuery] int offset = 0)
        {
             var pageModel = productService.GetProducts(limit, offset);
            return Ok(mapper.Map<PageResponse<ProductResponse>>(pageModel));
        }


        /// <summary>
        /// Update Product
        /// </summary>
        [HttpPut]
        [Route("{id}")]
        public IActionResult UpdateProduct([FromRoute] Guid id, [FromBody] UpdateProductRequest model)
        {
            var validationResult = model.Validate();
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }
            try
            {
                var resultModel = productService.UpdateProduct(id, mapper.Map<UpdateProductModel>(model));

                return Ok(mapper.Map<ProductResponse>(resultModel));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Delete Product
        /// </summary>
        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteProduct([FromRoute] Guid id)
        {
            try
            {
                productService.DeleteProduct(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Get Product
        /// </summary>
        [HttpGet]
        [Route("{id}")]
        public IActionResult GetProduct([FromRoute] Guid id)
        {
            try
            {
                var productModel = productService.GetProduct(id);
                return Ok(mapper.Map<ProductResponse>(productModel));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    }
}
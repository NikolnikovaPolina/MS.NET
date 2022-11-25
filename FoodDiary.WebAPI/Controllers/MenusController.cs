using AutoMapper;
using FoodDiary.Services.Abstract;
using FoodDiary.Services.Models;
using FoodDiary.WebAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace FoodDiary.WebAPI.Controllers
{
    /// <summary>
    /// Menus endpoints
    /// </summary>
    [ProducesResponseType(200)]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class MenusController : ControllerBase
    {
        private readonly IMenuService menuService;
        private readonly IMapper mapper;

        /// <summary>
        /// Menus controller
        /// </summary>
        public MenusController(IMenuService menuService, IMapper mapper)
        {
            this.menuService = menuService;
            this.mapper = mapper;
        }
        /// <summary>
        /// Get Menus by pages
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetMenus([FromQuery] int limit = 20, [FromQuery] int offset = 0)
        {
             var pageModel = menuService.GetMenus(limit, offset);
            return Ok(mapper.Map<PageResponse<MenuResponse>>(pageModel));
        }


        /// <summary>
        /// Update Menu
        /// </summary>
        [HttpPut]
        [Route("{id}")]
        public IActionResult UpdateMenu([FromRoute] Guid id, [FromBody] UpdateMenuRequest model)
        {
            var validationResult = model.Validate();
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }
            try
            {
                var resultModel = menuService.UpdateMenu(id, mapper.Map<UpdateMenuModel>(model));

                return Ok(mapper.Map<MenuResponse>(resultModel));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Delete Menu
        /// </summary>
        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteMenu([FromRoute] Guid id)
        {
            try
            {
                menuService.DeleteMenu(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Get Menu
        /// </summary>
        [HttpGet]
        [Route("{id}")]
        public IActionResult GetMenu([FromRoute] Guid id)
        {
            try
            {
                var menuModel = menuService.GetMenu(id);
                return Ok(mapper.Map<UserResponse>(menuModel));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    }
}
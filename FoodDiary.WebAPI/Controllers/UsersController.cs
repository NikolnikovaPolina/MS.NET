using AutoMapper;
using FoodDiary.Services.Abstract;
using FoodDiary.Services.Models;
using FoodDiary.WebAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace FoodDiary.WebAPI.Controllers
{
    /// <summary>
    /// Users endpoints
    /// </summary>
    [ProducesResponseType(200)]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService userService;
        private readonly IMapper mapper;

        /// <summary>
        /// Users controller
        /// </summary>
        public UsersController(IUserService userService, IMapper mapper)
        {
            this.userService = userService;
            this.mapper = mapper;
        }

        /// <summary>
        /// Get users by pages
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetUsers([FromQuery] int limit = 20, [FromQuery] int offset = 0)
        {
            var pageModel = userService.GetUsers(limit, offset);
            return Ok(mapper.Map<PageResponse<UserResponse>>(pageModel));
        }

        /// <summary>
        /// Update user
        /// </summary>
        [HttpPut]
        [Route("{id}")]
        public IActionResult UpdateUser([FromRoute] Guid id, [FromBody] UpdateUserRequest user)
        {
            var validationResult = user.Validate();
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }
            try
            {
                var resultModel = userService.UpdateUser(id, mapper.Map<UpdateUserModel>(user));

                return Ok(mapper.Map<UserResponse>(resultModel));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Delete user
        /// </summary>
        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteUser([FromRoute] Guid id)
        {
            try
            {
                userService.DeleteUser(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Get user
        /// </summary>
        [HttpGet]
        [Route("{id}")]
        public IActionResult GetUser([FromRoute] Guid id)
        {
            try
            {
                var userModel = userService.GetUser(id);
                return Ok(mapper.Map<UserResponse>(userModel));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    }
}
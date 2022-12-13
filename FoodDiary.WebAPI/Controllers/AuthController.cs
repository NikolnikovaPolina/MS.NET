using AutoMapper;
using FoodDiary.Services.Abstract;
using FoodDiary.Services.Models;
using FoodDiary.WebAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FoodDiary.Controllers
{
    /// <summary>
    /// Users endpoints
    /// </summary>
    [ProducesResponseType(200)]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService authService;
        private readonly IMapper mapper;

        /// <summary>
        /// Authcontroller
        /// </summary>
        public AuthController(IAuthService  authService, IMapper mapper)
        {
            this.authService = authService;
            this.mapper = mapper;
        }
        /// <summary>
        /// register
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("registerUser")]
        public IActionResult RegisterUser([FromBody] RegisterUserModel model)
        {
            var registerModel = authService.RegisterUser(model);

            var response = mapper.Map<PageResponse<RegisterUserModel>>(model);

            return Ok(response); // code 200 + body
        }

        /// <summary>
        /// login
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("loginUser")]
        public IActionResult LogInUser([FromBody] LoginUserModel model)
        {
            var loginModel = authService.LoginUser(model);

            var response = mapper.Map<PageResponse<LoginUserModel>>(model);

            return Ok(response); // code 200 + body
        }
    }
}
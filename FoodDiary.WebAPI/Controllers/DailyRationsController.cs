using AutoMapper;
using FoodDiary.Services.Abstract;
using FoodDiary.Services.Models;
using FoodDiary.WebAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace FoodDiary.WebAPI.Controllers
{
    /// <summary>
    /// Daily ration endpoints
    /// </summary>
    [ProducesResponseType(200)]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class DailyRationsController : ControllerBase
    {
        private readonly IDailyRationService dailyRationService;
        private readonly IMapper mapper;

        /// <summary>
        /// Daily ration controller
        /// </summary>
        public DailyRationsController(IDailyRationService dailyRationService, IMapper mapper)
        {
            this.dailyRationService = dailyRationService;
            this.mapper = mapper;
        }
        /// <summary>
        /// Get Daily Rations by pages
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetDailyRations([FromQuery] int limit = 20, [FromQuery] int offset = 0)
        {
             var pageModel = dailyRationService.GetDailyRations(limit, offset);
            return Ok(mapper.Map<PageResponse<DailyRationResponse>>(pageModel));
        }


        /// <summary>
        /// Delete Daily ration
        /// </summary>
        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteDailyRation([FromRoute] Guid id)
        {
            try
            {
                dailyRationService.DeleteDailyRation(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }


        /// <summary>
        /// Add Daily ration
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IActionResult AddDailyRation([FromBody] DailyRationModel dailyRation)
        {
            var response = dailyRationService.AddDailyRation(dailyRation);
            return Ok(response);
        }

        /// <summary>
        /// Get Daily ration
        /// </summary>
        [HttpGet]
        [Route("{id}")]
        public IActionResult GetDailyRation([FromRoute] Guid id)
        {
            try
            {
                var dailyRationModel = dailyRationService.GetDailyRation(id);
                return Ok(mapper.Map<DailyRationResponse>(dailyRationModel));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    }
}
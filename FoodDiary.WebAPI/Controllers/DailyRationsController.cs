using AutoMapper;
using FoodDiary.Services.Abstract;
using FoodDiary.Services.Models;
using FoodDiary.WebAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace FoodDiary.WebAPI.Controllers
{
    /// <summary>
    /// DailyRations endpoints
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
        /// DailyRations controller
        /// </summary>
        public DailyRationsController(IDailyRationService dailyRationService, IMapper mapper)
        {
            this.dailyRationService = dailyRationService;
            this.mapper = mapper;
        }
        /// <summary>
        /// Get DailyRations by pages
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetDailyRations([FromQuery] int limit = 20, [FromQuery] int offset = 0)
        {
             var pageModel = dailyRationService.GetDailyRations(limit, offset);
            return Ok(mapper.Map<PageResponse<DailyRationResponse>>(pageModel));
        }


        /// <summary>
        /// Update DailyRation
        /// </summary>
        [HttpPut]
        [Route("{id}")]
        public IActionResult UpdateDailyRation([FromRoute] Guid id, [FromBody] UpdateDailyRationRequest dailyRation)
        {
            var validationResult = dailyRation.Validate();
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }
            try
            {
                var resultModel = dailyRationService.UpdateDailyRation(id, mapper.Map<UpdateDailyRationModel>(dailyRation));

                return Ok(mapper.Map<DailyRationResponse>(resultModel));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Delete DailyRation
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
        /// Add DailyRation
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IActionResult AddDailyRation([FromRoute] Guid userId, [FromBody] DailyRationModel dailyRation)
        {
            var response = dailyRationService.AddDailyRation(userId, dailyRation);
            return Ok(response);
        }

        /// <summary>
        /// Get DailyRation
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
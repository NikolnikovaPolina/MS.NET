using AutoMapper;
using FoodDiary.Services.Abstract;
using FoodDiary.Services.Models;
using FoodDiary.WebAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace FoodDiary.WebAPI.Controllers
{
    /// <summary>
    /// Goals endpoints
    /// </summary>
    [ProducesResponseType(200)]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class GoalsController : ControllerBase
    {
        private readonly IGoalService goalService;
        private readonly IMapper mapper;

        /// <summary>
        /// Goals controller
        /// </summary>
        public GoalsController(IGoalService goalService, IMapper mapper)
        {
            this.goalService = goalService;
            this.mapper = mapper;
        }
        /// <summary>
        /// Get Goals by pages
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetGoals([FromQuery] int limit = 20, [FromQuery] int offset = 0)
        {
             var pageModel = goalService.GetGoals(limit, offset);
            return Ok(mapper.Map<PageResponse<GoalResponse>>(pageModel));
        }


        /// <summary>
        /// Update Goal
        /// </summary>
        [HttpPut]
        [Route("{id}")]
        public IActionResult UpdateGoal([FromRoute] Guid id, [FromBody] UpdateGoalRequest goal)
        {
            var validationResult = goal.Validate();
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }
            try
            {
                var resultModel = goalService.UpdateGoal(id, mapper.Map<UpdateGoalModel>(goal));

                return Ok(mapper.Map<GoalResponse>(resultModel));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Delete Goal
        /// </summary>
        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteGoal([FromRoute] Guid id)
        {
            try
            {
                goalService.DeleteGoal(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Add Goal
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IActionResult AddGoal([FromRoute] Guid userId, [FromBody] GoalModel goal)
        {
            var response = goalService.AddGoal(userId, goal);
            return Ok(response);
        }

        /// <summary>
        /// Get Goal
        /// </summary>
        [HttpGet]
        [Route("{id}")]
        public IActionResult GetGoal([FromRoute] Guid id)
        {
            try
            {
                var goalModel = goalService.GetGoal(id);
                return Ok(mapper.Map<GoalResponse>(goalModel));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    }
}
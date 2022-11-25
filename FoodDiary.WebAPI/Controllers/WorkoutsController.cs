using AutoMapper;
using FoodDiary.Services.Abstract;
using FoodDiary.WebAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace FoodDiary.WebAPI.Controllers
{
    /// <summary>
    /// Workouts endpoints
    /// </summary>
    [ProducesResponseType(200)]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class WorkoutsController : ControllerBase
    {
        private readonly IWorkoutService workoutService;
        private readonly IMapper mapper;

        /// <summary>
        /// Workouts controller
        /// </summary>
        public WorkoutsController(IWorkoutService workoutService, IMapper mapper)
        {
            this.workoutService = workoutService;
            this.mapper = mapper;
        }
        /// <summary>
        /// Get Workouts by pages
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetWorkouts([FromQuery] int limit = 20, [FromQuery] int offset = 0)
        {
             var pageModel = workoutService.GetWorkouts(limit, offset);
            return Ok(mapper.Map<PageResponse<WorkoutResponse>>(pageModel));
        }

        /// <summary>
        /// Delete Workout
        /// </summary>
        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteWorkout([FromRoute] Guid id)
        {
            try
            {
                workoutService.DeleteWorkout(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Get Workout
        /// </summary>
        [HttpGet]
        [Route("{id}")]
        public IActionResult GetWorkout([FromRoute] Guid id)
        {
            try
            {
                var workoutModel = workoutService.GetWorkout(id);
                return Ok(mapper.Map<WorkoutResponse>(workoutModel));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    }
}
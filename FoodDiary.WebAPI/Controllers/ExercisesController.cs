using AutoMapper;
using FoodDiary.Services.Abstract;
using FoodDiary.WebAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace FoodDiary.WebAPI.Controllers
{
    /// <summary>
    /// Exercises endpoints
    /// </summary>
    [ProducesResponseType(200)]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class ExercisesController : ControllerBase
    {
        private readonly IExerciseService exerciseService;
        private readonly IMapper mapper;

        /// <summary>
        /// Exercises controller
        /// </summary>
        public ExercisesController(IExerciseService exerciseService, IMapper mapper)
        {
            this.exerciseService = exerciseService;
            this.mapper = mapper;
        }
        /// <summary>
        /// Get Exercises by pages
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetExercises([FromQuery] int limit = 20, [FromQuery] int offset = 0)
        {
             var pageModel = exerciseService.GetExercises(limit, offset);
            return Ok(mapper.Map<PageResponse<ExerciseResponse>>(pageModel));
        }

        /// <summary>
        /// Delete Exercise
        /// </summary>
        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteExercise([FromRoute] Guid id)
        {
            try
            {
                exerciseService.DeleteExercise(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Get Exercise
        /// </summary>
        [HttpGet]
        [Route("{id}")]
        public IActionResult GetExercise([FromRoute] Guid id)
        {
            try
            {
                var exerciseModel = exerciseService.GetExercise(id);
                return Ok(mapper.Map<UserResponse>(exerciseModel));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    }
}
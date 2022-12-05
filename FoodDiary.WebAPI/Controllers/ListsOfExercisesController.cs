using AutoMapper;
using FoodDiary.Services.Abstract;
using FoodDiary.Services.Models;
using FoodDiary.WebAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace FoodDiary.WebAPI.Controllers
{
    /// <summary>
    /// ListsOfExercises endpoints
    /// </summary>
    [ProducesResponseType(200)]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class ListsOfExercisesController : ControllerBase
    {
        private readonly IListOfExercisesService listOfExercisesService;
        private readonly IMapper mapper;

        /// <summary>
        /// ListsOfExercises controller
        /// </summary>
        public ListsOfExercisesController(IListOfExercisesService listOfExercisesService, IMapper mapper)
        {
            this.listOfExercisesService = listOfExercisesService;
            this.mapper = mapper;
        }
        /// <summary>
        /// Get ListsOfExercises by pages
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetListsOfExercises([FromQuery] int limit = 20, [FromQuery] int offset = 0)
        {
             var pageModel = listOfExercisesService.GetListsOfExercises(limit, offset);
            return Ok(mapper.Map<PageResponse<ListOfExercisesResponse>>(pageModel));
        }

        /// <summary>
        /// Update ListOfExerciseS
        /// </summary>
        [HttpPut]
        [Route("{id}")]
        public IActionResult UpdateListOfExercises([FromRoute] Guid id, [FromBody] UpdateListOfExercisesRequest listOfExercises)
        {
            var validationResult = listOfExercises.Validate();
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }
            try
            {
                var resultModel = listOfExercisesService.UpdateListOfExercises(id, mapper.Map<UpdateListOfExercisesModel>(listOfExercises));

                return Ok(mapper.Map<ListOfExercisesResponse>(resultModel));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Delete ListOfExercises
        /// </summary>
        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteListOfExercises([FromRoute] Guid id)
        {
            try
            {
                listOfExercisesService.DeleteListOfExercises(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

         /// <summary>
        /// Add ListOfExercises
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IActionResult AddListOfExercise([FromRoute] Guid exerciseId, [FromRoute] Guid workoutId, [FromBody] ListOfExercisesModel listOfExercises)
        {
            var response = listOfExercisesService.AddListOfExercises(exerciseId, workoutId, listOfExercises);
            return Ok(response);
        }

        /// <summary>
        /// Get ListOfExercises
        /// </summary>
        [HttpGet]
        [Route("{id}")]
        public IActionResult GetListOfExercises([FromRoute] Guid id)
        {
            try
            {
                var listOfExercisesModel = listOfExercisesService.GetListOfExercises(id);
                return Ok(mapper.Map<ListOfExercisesResponse>(listOfExercisesModel));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    }
}
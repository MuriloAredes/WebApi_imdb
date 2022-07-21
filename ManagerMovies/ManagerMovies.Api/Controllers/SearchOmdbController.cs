using ManagerMovies.Application.Services.SearchOmdbServices.Query.GetAllService;
using ManagerMovies.Contracts.SearchOmdbContracts;
using Microsoft.AspNetCore.Mvc;

namespace ManagerMovies.Api.Controllers
{

    /// <summary>
    /// SearchController
    /// </summary>
    [ApiController]
    [Produces("application/json")]
    public class SearchOmdbController: ControllerBase
    {
        private readonly IGetAllMoviesOmdbService _getAllMoviesOmdbService;
        public SearchOmdbController(IGetAllMoviesOmdbService getAllMoviesOmdbService)
        {
            _getAllMoviesOmdbService = getAllMoviesOmdbService;
        }

        [HttpPost("api/[controller]/GetAllMovies")]
        public async Task<IActionResult> GetAllMovies([FromBody] GetAllMoviesOmdRequest request)
        {
            try
            {     
                if (string.IsNullOrEmpty(request.Title) && string.IsNullOrEmpty(request.Id))
                      return Ok("just one of the fields");

                var result = await _getAllMoviesOmdbService.GetAll(new GetAllMoviesOmdRequest
                {
                    Title = request.Title,
                    Id = request.Title,
                    year = request.year

                }); ;

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}

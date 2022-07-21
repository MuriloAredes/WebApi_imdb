using ManagerMovies.Application.Services.MovieServices.Command.Create;
using ManagerMovies.Application.Services.MovieServices.Command.Remove;
using ManagerMovies.Application.Services.MovieServices.Command.Update;
using ManagerMovies.Application.Services.MovieServices.Command.UpdateStatus;
using ManagerMovies.Application.Services.MovieServices.Queries.GetAll;
using ManagerMovies.Contracts.Create;
using ManagerMovies.Contracts.GetAll;
using ManagerMovies.Contracts.Remove;
using ManagerMovies.Contracts.Update;
using ManagerMovies.Domain.Enum;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace ManagerMovies.Api.Controllers
{/// <summary>
 /// UserController
 /// </summary>
    [ApiController]
    [Produces("application/json")]
    public class MovieController : ControllerBase
    {
        private readonly IGetAllMoviesService _getAllMoviesService;
        private readonly IRegisterMovieService _createMovieService;
        private readonly IRemoveMovieService _removeMovieService;
        private readonly IUpdateMovieService _updateMovieService;
        private readonly IUpdateStatusService _updateStatusService;
        public MovieController(IGetAllMoviesService getAllMoviesHandler,
                               IRegisterMovieService createMovieService,
                               IRemoveMovieService removeMovieService, 
                               IUpdateMovieService updateMovieService,
                               IUpdateStatusService updateStatusService)
        {
            _getAllMoviesService = getAllMoviesHandler;
            _createMovieService = createMovieService;
            _removeMovieService = removeMovieService;
            _updateMovieService = updateMovieService;
            _updateStatusService = updateStatusService;
        }

        /// <summary>
        /// Get all Movies
        /// </summary>
        /// <param name="search"> search field</param>
        /// <param name="page">Pagination initial 1</param>
        /// <param name="pageSize">Page Size</param>
        /// <param name="colunmSort">sort by column , none = 0, Name = 1, DateRelease = 2 , Genre =3  </param>
        /// <param name="isAsc">choose a column and send positive</param>
        /// <returns>buscart</returns>       
        [HttpGet("api/[controller]/GetAllMovies")]
        public async Task<IActionResult> GetAllMovies(string? search, int page, int? pageSize, MovieEnum colunmSort, bool isAsc = false)
        {
            try
            {
                var result = await _getAllMoviesService.GetAll(new MovieRequest
                {
                    Search = search,
                    Page = page = 1,
                    PageSize = pageSize.GetValueOrDefault(20),
                    ColunmSort = colunmSort,
                    IsAsc = isAsc
                });

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        /// <summary>
        /// Regiter movies
        /// </summary>
        [HttpPost("api/[controller]/RegisterMovies")]
        public async Task<IActionResult> RegisterMovies(string id)
        {
            try
            {
                var result = await _createMovieService.RegisterMovie(new RegisterMovieRequest { ImdbId = id });

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
        /// <summary>
        /// Remove movies
        /// </summary>
        [HttpDelete("api/[controller]/RemoveMovies")]
        public async Task<IActionResult> RemoveMovies(int id)
        {
            try
            {
                var result = await _removeMovieService.Remover(new RemoveMovieRequest (id));

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        /// <summary>
        /// update Movies
        /// </summary>
        [HttpPut("api/[controller]/UpdateMovies")]
        public async Task<IActionResult> UpdateMovies([FromBody]UpdateMovieRequest request)
        {
            try
            {
                var result = await _updateMovieService.Update(request);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
        /// <summary>
        /// Update Assisted Status
        /// </summary>
        [HttpPut("api/[controller]/UpdateAssistedStatus")]
        public async Task<IActionResult> UpdateAssistedStatus(int id)
        {
            try
            {
                var result = await _updateStatusService.UpdateStatus(id);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}

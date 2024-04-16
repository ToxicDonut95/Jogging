using AutoMapper;
using Jogging.Contracts.Interfaces.RepoInterfaces;
using Jogging.Domain.DomeinControllers;
using Jogging.Domain.Helpers;
using Jogging.Domain.Models;
using Jogging.Infrastructure.Models;
using Jogging.Rest.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Jogging.Rest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
#if ProducesConsumes
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]
#endif
    public class CompetitionController : ControllerBase
    {
        #region Props

        private readonly CompetitionManager _competitionManager;
        private readonly IMapper _mapper;

        #endregion

        #region CTor

        public CompetitionController(CompetitionManager competitionManager, IMapper mapper)
        {
            _competitionManager = competitionManager;
            _mapper = mapper;
        }

        #endregion

        #region GET

        [HttpGet]
        public async Task<ActionResult<PagedList<CompetitionResponseDOM>>> GetAll([FromQuery] QueryStringParameters parameters)
        {
            try
            {
                var competitions = await _competitionManager.GetAll(parameters);

                var metadata = new
                {
                    competitions.TotalCount,
                    competitions.PageSize,
                    competitions.CurrentPage,
                    competitions.TotalPages,
                    competitions.HasNext,
                    competitions.HasPrevious
                };

                Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));

                return Ok(competitions);
            }
            catch (Exception exception)
            {
                return NotFound(exception.Message);
            }
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<CompetitionRequestDTO>> Get(int id)
        {
            try
            {
                var response = await _competitionManager.GetById(id);

                if (response != null)
                {
                    return Ok(_mapper.Map<CompetitionRequestDTO>(response));
                }

                return BadRequest($"No competition found with id {id}.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An unexpected error occurred while processing your request.");
            }
        }

        #endregion

        #region POST

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<CompetitionResponseDTO>> Post([FromBody] CompetitionRequestDTO competitionRequestDto)
        {
            try
            {
                var response = await _competitionManager.AddAsync(_mapper.Map<CompetitionRequestDOM>(competitionRequestDto));

                if (response != null)
                {
                    return Ok(_mapper.Map<CompetitionResponseDTO>(response));
                }

                return BadRequest("Failed to add competition. Check your input data.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An unexpected error occurred while processing your request.");
            }
        }

        #endregion

        #region PUT

        [HttpPut("{id}")]
        [Authorize]
        public async Task<ActionResult<CompetitionResponseDTO>> Put(int id, [FromBody] CompetitionRequestDTO competitionRequestDto)
        {
            try
            {
                var response = await _competitionManager.UpdateAsync(id, _mapper.Map<CompetitionRequestDOM>(competitionRequestDto));

                if (response != null)
                {
                    return Ok(_mapper.Map<CompetitionResponseDTO>(response));
                }

                return BadRequest("Failed to update competition. Check your input data.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An unexpected error occurred while processing your request.");
            }
        }

        #endregion

        #region DELETE

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                await _competitionManager.DeleteAsync(id);

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An unexpected error occurred while processing your request.");
            }
        }

        #endregion
    }
}
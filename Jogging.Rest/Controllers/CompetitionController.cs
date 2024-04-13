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
        public async Task<ActionResult<PagedList<CompetitionDOM>>> GetAll([FromQuery] QueryStringParameters parameters)
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
                return NotFound(null);
            }
        }


        [HttpGet("{id}")]
        public ActionResult<AccountDOM> Get(int id)
        {
            return Ok(_competitionManager.GetById(id));
        }

        #endregion

        #region POST

        [HttpPost]
        public ActionResult<AccountDOM>? Post([FromBody] AccountDOM account)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region PUT

        [HttpPut]
        public ActionResult<bool> Put([FromBody] AccountDOM account)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region DELETE

        [HttpDelete]
        public ActionResult<bool> Delete([FromBody] AccountDOM account)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
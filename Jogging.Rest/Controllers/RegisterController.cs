using AutoMapper;
using Jogging.Domain.DomeinControllers;
using Jogging.Domain.Helpers;
using Jogging.Domain.Models;
using Jogging.Rest.DTOs;
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
    public class RegisterController : ControllerBase
    {
        #region Props

        private readonly PersonsManager _personDomain;
        private readonly IMapper _mapper;

        #endregion

        #region CTor

        public RegisterController(PersonsManager personDomain, IMapper mapper)
        {
            _personDomain = personDomain;
            _mapper = mapper;
        }

        #endregion

        #region POST

        [HttpPost]
        public async Task<ActionResult<bool>> Post([FromBody] LogInDTO person)
        {
            try
            {
                var success = await _personDomain.SignUpAsync(person.email, person.password);
                return Ok(success);
            }
            catch (Exception exception)
            {
                if (exception.Message != null)
                {
                    return BadRequest(exception.Message);
                }

                return BadRequest(false);
            }
        }

        #endregion
    }
}
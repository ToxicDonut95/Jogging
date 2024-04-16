using AutoMapper;
using Jogging.Domain.DomeinControllers;
using Jogging.Domain.Models;
using Jogging.Rest.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Jogging.Rest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonsController : ControllerBase
    {
        #region Props

        private readonly PersonsManager _personDomain;
        private readonly IMapper _mapper;

        #endregion Props

        #region CTor

        public PersonsController(PersonsManager personDomain, IMapper mapper)
        {
            _personDomain = personDomain;
            _mapper = mapper;
        }

        #endregion CTor

        #region GET

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<IEnumerable<PersonResponseDTO>>?> GetAll()
        {
            try
            {
                var persons = await _personDomain.GetAllAsync();

                if (persons == null || !persons.Any())
                {
                    return NotFound("No persons found.");
                }

                var personDtoIEnumerable = _mapper.Map<IEnumerable<PersonResponseDTO>>(persons);
                return Ok(personDtoIEnumerable);
            }
            catch (Exception exception)
            {
                return NotFound(null);
            }
        }

        #endregion GET

        #region POST

        [HttpPost]
        public async Task<ActionResult<int>>? CreatePerson([FromBody] PersonResponseDTO personResponse)
        {
            //try
            //{
            var result = await _personDomain.CreatePerson(_mapper.Map<PersonResponseDOM>(personResponse));
            return Ok(result);
            //}
            //catch (Exception ex)
            //{
            //    return BadRequest(false);
            //}
        }

        #endregion POST
    }
}
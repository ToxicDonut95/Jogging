using AutoMapper;
using Jogging.Domain.DomeinControllers;
using Jogging.Rest.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Jogging.Rest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonsController : ControllerBase
    {
        #region Props

        PersonsManager _personDomein;
        IMapper _mapper;

        #endregion

        #region CTor

        public PersonsController(PersonsManager personDomein, IMapper mapper)
        {
            _personDomein = personDomein;
            _mapper = mapper;
        }

        #endregion

        #region GET

        #endregion

        #region POST

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PersonDTO>>?> GetAll()
        {
            try
            {
                var persons = await _personDomein.GetAllAsync();
                var personDtoIEnumerable = _mapper.Map<IEnumerable<PersonDTO>>(persons);
                return Ok(personDtoIEnumerable);
            }
            catch (Exception exception)
            {
                return NotFound(null);
            }
        }

        #endregion

        #region PUT

        #endregion

        #region DELETE

        #endregion
    }
}
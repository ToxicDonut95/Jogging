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
        public ActionResult<IEnumerable<PersonDTO>>? Getall()
        {
            try
            {
                return Ok(_personDomein.GetAll().Select(person => _mapper.Map<PersonDTO>(person)));
            }
            catch (Exception)
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

using AutoMapper;
using Jogging.Domain.DomeinControllers;
using Jogging.Rest.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Jogging.Rest.Controllers;


#if ProducesConsumes
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]
#endif
[Route("api/[controller]")]
[ApiController]
public class LoginController : ControllerBase
{
    #region Props

    PersonsManager _personDomein;
    IMapper _mapper;

    #endregion

    #region CTor
    public LoginController(PersonsManager personDomein, IMapper mapper)
    {
        _personDomein = personDomein;
        _mapper = mapper;
    }

    #endregion

    #region GET

    #endregion

    #region POST

    [HttpPost]
    public ActionResult<bool>? LogIn([FromBody] LogInDTO person)
    {
        try
        {
            return Ok(_personDomein.LogIn(person.email, person.password));
        }
        catch (Exception)
        {

            return BadRequest(false);
        }

    }

    #endregion

    #region PUT

    #endregion

    #region DELETE

    #endregion
}
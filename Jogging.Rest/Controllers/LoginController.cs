using AutoMapper;
using Jogging.Domain.DomeinControllers;
using Jogging.Rest.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Jogging.Rest.Controllers;

[Route("api/[controller]")]
[ApiController]
#if ProducesConsumes
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]
#endif
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
        return _personDomein.LogIn(person.email, person.password);
    }

    #endregion

    #region PUT

    #endregion

    #region DELETE

    #endregion
}
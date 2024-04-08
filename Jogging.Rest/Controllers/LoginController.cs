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

    private readonly PersonsManager _personDomain;
    private readonly IMapper _mapper;

    #endregion

    #region CTor
    public LoginController(PersonsManager personDomain, IMapper mapper)
    {
        _personDomain = personDomain;
        _mapper = mapper;
    }

    #endregion

    #region GET

    #endregion

    #region POST

    [HttpPost]
    public async Task<ActionResult<bool>> LogInAsync([FromBody] LogInDTO person)
    {
        try
        {
            var success = await _personDomain.LogInAsync(person.email, person.password);
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

    #region PUT

    #endregion

    #region DELETE

    #endregion
}
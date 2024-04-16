using AutoMapper;
using Jogging.Infrastructure.Interfaces;
using Jogging.Infrastructure.Models;
using Jogging.Rest.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Jogging.Rest.Controllers;

#if ProducesConsumes
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]
#endif

[Route("api/[controller]")]
[ApiController]
public class CompetitionSignInController : ControllerBase
{
    #region Props

    private IRegistrationRepo _registrationRepo;
    private IMapper _mapper;

    #endregion Props

    #region CTor

    public CompetitionSignInController(IRegistrationRepo registrationRepo, IMapper mapper)
    {
        _registrationRepo = registrationRepo;
        _mapper = mapper;
    }

    #endregion CTor

    #region GET

    [HttpGet]
    public async Task<ActionResult<IEnumerable<CompetitionPerCategory>>?> GetRegisteredCompetionsOfPerson(int personId)
    {
        var result = await _registrationRepo.GetRegisteredCompetionsOfPerson(personId);
        return Ok(result);
    }

    #endregion GET

    #region POST

    [HttpPost]
    public async Task<ActionResult<bool>>? RegisterToContest([FromBody] RegistrationRequestDTO registrationRequest)
    {
        //try
        //{
        await _registrationRepo.SigninToContestAsync(_mapper.Map<Registration>(registrationRequest), registrationRequest.PersonId);
        return Ok(true);
        //}
        //catch (Exception ex)
        //{
        //    return BadRequest(false);
        //}
    }

    #endregion POST
}
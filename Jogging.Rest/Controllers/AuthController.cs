using AutoMapper;
using Jogging.Api.Configuration;
using Jogging.Domain.DomeinControllers;
using Jogging.Rest.DTOs;
using Jogging.Rest.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Net.Mime;
using System.Threading.Tasks;
using Jogging.Infrastructure.Interfaces;

namespace Jogging.Rest.Controllers
{
    #if ProducesConsumes
        [Produces(MediaTypeNames.Application.Json)]
        [Consumes(MediaTypeNames.Application.Json)]
    #endif
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly PersonsManager _personDomain;
        private readonly IMapper _mapper;
        private readonly JwtConfiguration _configuration;
        private readonly ITokenBlacklistService _tokenBlacklistService;

        public AuthController(PersonsManager personDomain, IMapper mapper, IOptions<JwtConfiguration> configuration, ITokenBlacklistService tokenBlacklistService)
        {
            _personDomain = personDomain ?? throw new ArgumentNullException(nameof(personDomain));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _configuration = configuration?.Value ?? throw new ArgumentNullException(nameof(configuration));
            _tokenBlacklistService = tokenBlacklistService;
        }

        [HttpPost("login")]
        public async Task<ActionResult<bool>> LogInAsync([FromBody] LogInDTO person)
        {
            try
            {
                var success = await _personDomain.LogInAsync(person.email, person.password);
                if (success != null)
                {
                    var jwtToken = JwtTokenUtil.Generate(_configuration); // Assuming success.UserId is the user's unique identifier

                    return Ok(new { Success = success, JwtToken = jwtToken });
                }

                return BadRequest();
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

        [HttpPost("logout")]
        public async Task<ActionResult<bool>> LogOutAsync()
        {
            var token = HttpContext.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            if (token != null)
            {
                _tokenBlacklistService.AddToBlacklist(token);
                return Ok(true);
            }

            return BadRequest("Invalid token");
        }
        
        [HttpPost("register")]
        public async Task<ActionResult<bool>> RegisterAsync([FromBody] LogInDTO person)
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
    }
}

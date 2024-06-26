﻿using AutoMapper;
using Jogging.Api.Configuration;
using Jogging.Domain.DomeinControllers;
using Jogging.Rest.DTOs;
using Jogging.Rest.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Net.Mime;
using System.Threading.Tasks;
using Jogging.Domain.Models;
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
        private readonly AuthManager _authManager;
        private readonly IMapper _mapper;
        private readonly JwtConfiguration _configuration;
        private readonly ITokenBlacklistService _tokenBlacklistService;

        public AuthController(AuthManager authManager, IMapper mapper, IOptions<JwtConfiguration> configuration,
            ITokenBlacklistService tokenBlacklistService)
        {
            _authManager = authManager ?? throw new ArgumentNullException(nameof(authManager));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _configuration = configuration?.Value ?? throw new ArgumentNullException(nameof(configuration));
            _tokenBlacklistService = tokenBlacklistService;
        }

        [HttpPost("login")]
        public async Task<ActionResult<PersonResponseDTO>> LogInAsync([FromBody] LogInRequestDTO person)
        {
            try
            {
                var success = await _authManager.LogInAsync(person.email, person.password);
                if (success?.UserId != null)
                {
                    var jwtToken =
                        JwtTokenUtil.Generate(_configuration,
                            success.UserId.ToString());

                    return Ok(new { Person = _mapper.Map<PersonResponseDTO>(success), JwtToken = jwtToken });
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
        public async Task<ActionResult<PersonResponseDTO>> SignUpAsync([FromBody] SignUpRequestDTO signUpRequestDto)
        {
            try
            {
                var personDOM = _mapper.Map<PersonRequestDOM>(signUpRequestDto.Person);
                var success =
                    await _authManager.SignUpAsync(signUpRequestDto.email, signUpRequestDto.password, personDOM);
                return Ok(_mapper.Map<PersonResponseDTO>(success));
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message ?? "An error occurred during sign up.");
            }
        }

        [HttpPost("request-password")]
        public async Task<ActionResult<bool>> RequestPasswordAsync([FromBody] PasswordRequestDto person)
        {
            try
            {
                var success = await _authManager.RequestPasswordAsync(person.Email);
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
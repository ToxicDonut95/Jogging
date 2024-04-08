﻿using AutoMapper;
using Jogging.Api.Configuration;
using Jogging.Domain.DomeinControllers;
using Jogging.Rest.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Jogging.Rest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonsController : ControllerBase
    {
        #region Props

        private readonly PersonsManager _personDomain;
        private readonly IMapper _mapper;

        #endregion

        #region CTor

        public PersonsController(PersonsManager personDomain, IMapper mapper)
        {
            _personDomain = personDomain;
            _mapper = mapper;
        }

        #endregion

        #region GET

        #endregion

        #region POST

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<IEnumerable<PersonDTO>>?> GetAll()
        {
            try
            {
                var persons = await _personDomain.GetAllAsync();
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
﻿using AutoMapper;
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

        #endregion

        #region CTor

        public PersonsController(PersonsManager personDomain, IMapper mapper)
        {
            _personDomain = personDomain;
            _mapper = mapper;
        }

        #endregion

        #region GET

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

        #region POST

        [HttpPost]
        public async Task<ActionResult<PersonDTO>>? CreatePerson([FromBody] PersonDTO person)
        {
            //try
            //{
            var result=_mapper.Map<PersonDTO>( await _personDomain.CreatePerson(_mapper.Map<PersonDOM>(person)));
            return Ok(result);
            //}
            //catch (Exception ex)
            //{
            //    return BadRequest(false);
            //}
        }

        #endregion

        #region PUT

        #endregion

        #region DELETE

        #endregion
    }
}
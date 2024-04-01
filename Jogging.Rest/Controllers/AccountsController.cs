using Assignment.Domain.Helpers;
using AutoMapper;
using Jogging.Domain.Interfaces;
using Jogging.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Jogging.Rest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
#if ProducesConsumes
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]
#endif
    public class AccountsController : ControllerBase
    {
        #region Props
        Irepo<Account> _accountRepo;
        IMapper _mapper;
        #endregion
        #region CTor
        public AccountsController(Irepo<Account> accountRepo, IMapper mapper)
        {
            _accountRepo = accountRepo;
            _mapper = mapper;
        }
        #endregion
        #region GET
        public ActionResult<Account> GetAll([FromQuery] QueryStringParameters parameters)
        {
            var emps = _accountRepo.GetAll(parameters);

            var metaData = new
            {
                emps.TotalCount,
                emps.PageSize,
                emps.CurrentPage,
                emps.TotalPages,
                emps.HasNext,
                emps.HasPrevious
            };

            Response.Headers.Append("X-Pagination", JsonConvert.SerializeObject(metaData));

            return Ok(emps);
        }
        public ActionResult<Account> Get(int id)
        {
            return Ok(_accountRepo.GetById(id));
        }

        #endregion

        #region POST
        public ActionResult<Account>? Post([FromBody] Account employee)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region PUT
        public ActionResult<bool> Put([FromBody] Account employee)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region DELETE
        public ActionResult<bool> Delete([FromBody] Account employee)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}

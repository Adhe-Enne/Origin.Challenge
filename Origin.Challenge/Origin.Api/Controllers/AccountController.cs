using Origin.Model;
using Origin.Business.Service;
using Core.Abstractions;
using Core.Framework;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Origin.Model.DTO;

namespace Origin.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : BaseController
    {
        private readonly IService<Account> _accountService;
        public AccountController(
            IService<Account> accountService,
            IMapper mapper
            ) : base(mapper)
        {
            this._accountService = accountService;
        }

        [HttpGet]
        public ApiResult<IEnumerable<AccountDTO>> GetAccountInfo()
        {
            ApiResult<IEnumerable<AccountDTO>> result = new();

            _LogInfo("Tomando Maestro de Cuentas");

            try
            {
                var accounts = _accountService.Filter(x => x.IsEnabled , p => p.Cards).ToList();

                result.Data = _mapper.Map<IEnumerable<AccountDTO>>(accounts);

            }
            catch (Exception ex)
            {
                result.Set(HandleException(ex));
            }

            return result;
        }

    }
}

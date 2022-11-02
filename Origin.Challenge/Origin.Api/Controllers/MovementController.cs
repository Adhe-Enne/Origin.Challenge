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
    public class MovementController : BaseController
    {
        private readonly IService<Movement> _movementService;
        public MovementController(
            IService<Movement> movementService,
            IMapper mapper
            ) : base(mapper)
        {
            this._movementService = movementService;
        }

        [HttpGet]
        public ApiResult<IEnumerable<MovementDTO>> GetAccountInfo()
        {
            ApiResult<IEnumerable<MovementDTO>> result = new();

            _LogInfo("Obteniendo Maestro de Movimientos");

            try
            {
                var movements = _movementService.Filter(x => x.IsEnabled, p => p.Card.Owner);

                result.Data = _mapper.Map<IEnumerable<MovementDTO>>(movements);

            }
            catch (Exception ex)
            {
                result.Set(HandleException(ex));
            }

            return result;
        }

        [HttpGet("{ownerId}")]
        public ApiResult<IEnumerable<MovementDTO>> GetAccountInfo(int ownerId)
        {
            ApiResult<IEnumerable<MovementDTO>> result = new();

            _LogInfo("Obteniendo Maestro de Movimientos");

            try
            {
                var movements = _movementService.Filter(
                    x => x.IsEnabled
                    && x.Card.OwnerId == ownerId,
                    p => p.Card.Owner).ToList();

                result.Data = _mapper.Map<IEnumerable<MovementDTO>>(movements);

            }
            catch (Exception ex)
            {
                result.Set(HandleException(ex));
            }

            return result;
        }
    }
}

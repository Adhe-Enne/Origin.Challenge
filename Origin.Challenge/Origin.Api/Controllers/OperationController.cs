using Origin.Model;
using Origin.Business.Service;
using Core.Abstractions;
using Core.Framework;
using Microsoft.AspNetCore.Mvc;
using Origin.Business.Interfaces;
using Origin.Model.DTO;
using AutoMapper;

namespace Origin.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OperationController : BaseController
    {
        private readonly ICardService _cardService;
        public OperationController(
            ICardService cardService,
            IMapper mapper
            ) : base(mapper)
        {
            this._cardService = cardService;
        }

        [HttpPost("balance")]
        public ApiResult<CardDTO> BalanceCard([FromBody]CardDTO entity)
        {
            _LogInfo("Balance en Marcha", entity);

            ApiResult<CardDTO> result = new();

            try
            {
                var response = _cardService.BalanceCard(entity.codeNumber, entity.pinNumber, out string message);
                 result.Data = _mapper.Map<CardDTO>(response);

                if (string.IsNullOrEmpty(message))
                    _LogInfo("Balance Exitoso");
                else
                    _LogWarn(message);
            }
            catch (Exception ex)
            {
                result.Set(HandleException(ex));
            }
            return result;
        }

        [HttpPost("withdraw")]
        public GenericResult WithDrawBalance([FromBody] CardDTO entity)
        {
            _LogInfo($"Extracion: ARS$ {entity.WithDraw} ", entity);

            GenericResult result = new();

            try
            {
                _cardService.WithDraw(entity.codeNumber, entity.pinNumber, entity.WithDraw);

                _LogInfo("Extraccion Exitosa");
            }
            catch (Exception ex)
            {
                result.Set(HandleException(ex));
            }

            return result;
        }

        [HttpGet("movements/{number}/{pin}")]
        public ApiResult<IEnumerable<MovementDTO>> GetMovements(string number, string pin)
        {
            _LogInfo("Obteniendo Movimientos, Tarjeta Numero: " + number);

            ApiResult<IEnumerable<MovementDTO>> result = new();

            try
            {
                var movements = _cardService.Find(
                    x => x.CodeNumber == number
                    && x.Pin == pin,
                    p => p.Movements)
                    .Movements
                    .OrderByDescending(x => x.OperationDay);

                if(movements is not null && movements.Any())
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



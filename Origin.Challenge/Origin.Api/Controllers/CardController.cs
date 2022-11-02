using Origin.Model;
using Origin.Business.Service;
using Core.Abstractions;
using Origin.Business.Interfaces;
using Core.Framework;
using Microsoft.AspNetCore.Mvc;
using Origin.Model.DTO;
using AutoMapper;

namespace Origin.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CardController : BaseController
    {
        private readonly ICardService _cardService;

        public CardController(
            ICardService cardService,
            IMapper mapper
            ) : base(mapper)
        {
            this._cardService = cardService;
        }

        [HttpGet]
        public ApiResult<IEnumerable<CardDTO>> GetCardInfo()
        {
            ApiResult<IEnumerable<CardDTO>> result = new();

            try
            {
                var cards = _cardService.Filter( x=> true, p=> p.Owner).ToList();

                result.Data = _mapper.Map<IEnumerable<CardDTO>>(cards);
            }
            catch (Exception ex)
            {
                result.Set(HandleException(ex));
            }

            return result;
        }

        [HttpGet("{codeNumber}")]
        public GenericResult ValidateCodeNumber(string codeNumber)
        {
            _LogInfo("Buscando Tarjeta - Numero: "+codeNumber);
            GenericResult result = new();

            try
            {
                _cardService.ValidateCodeNumber(codeNumber);
            }
            catch (Exception ex)
            {
                result.Set(HandleException(ex));
            }

            return result;
        }

        [HttpPost("pin")]
        public ApiResult<CardDTO> ValidatePIN([FromBody]CardDTO card)
        {
            _LogInfo($"Validando PIN - Numero: {card.codeNumber}, PIN: {card.pinNumber} ");

            ApiResult<CardDTO> result = new();
            
            try
            {
                var response = _cardService.ValidatePIN(card.codeNumber, card.pinNumber);
                result.Data = _mapper.Map<CardDTO>(response);
            }
            catch (Exception ex)
            {
                result.Set(HandleException(ex));
            }

            return result;
        }
    }
}

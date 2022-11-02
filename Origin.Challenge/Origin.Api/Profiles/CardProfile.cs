using Origin.Model;
using Origin.Model.DTO;
using AutoMapper;
namespace Origin.Api.Profiles
{
    public class CardProfile : Profile
    {
        public CardProfile()
        {
            CreateMap<Card, CardDTO>()
                     .ForMember(dest => dest.codeNumber, opt => opt.MapFrom(res => res.CodeNumber))
                     .ForMember(dest => dest.Owner, opt => opt.MapFrom(res => res.Owner.OwnerName))
                     .ForMember(dest => dest.cardType, opt => opt.MapFrom(res => res.CardType.ToString()))
                     .ForMember(dest => dest.pinNumber, opt => opt.MapFrom(res => res.Pin))
                     .ForMember(dest => dest.description, opt => opt.MapFrom(res => res.Description))
                     .ForMember(dest => dest.dueDate, opt => opt.MapFrom(res => Core.Framework.Common.ToString(res.DueDate)));
        }
    }
}

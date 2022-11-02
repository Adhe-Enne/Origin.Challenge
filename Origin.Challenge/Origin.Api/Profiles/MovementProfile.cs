using Origin.Model;
using Origin.Model.DTO;
using AutoMapper;

namespace Origin.Api.Profiles
{
    public class MovementProfile : Profile
    {
        public MovementProfile()
        {

            CreateMap<Movement, MovementDTO>()
                     .ForMember(dest => dest.OperationDay, opt => opt.MapFrom(res => Core.Framework.Common.ToString(res.OperationDay)))
                     .ForMember(dest => dest.Owner, opt => opt.MapFrom(res => res.Card.Owner.OwnerName))
                     .ForMember(dest => dest.CardNumber, opt => opt.MapFrom(res => res.Card.CodeNumber));
        }
    }
}

using Origin.Model;
using Origin.Model.DTO;
using AutoMapper;

namespace Origin.Api.Profiles
{
    public class AccountProfile : Profile
    {
        public AccountProfile()
        {
            CreateMap<Account, AccountDTO>()
                .ForMember(dest => dest.Owner, opt => opt.MapFrom(res => res.OwnerName));
        }
    }
}

using AutoMapper;
using DiscoCordAPI.Models.Servers;
using DiscoCordAPI.Models.Users;

namespace DiscoCordAPI.Web.Api.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<User, UserForDetailedDto>();
            CreateMap<Server, ServerForUserListDto>();
        }
    }
}
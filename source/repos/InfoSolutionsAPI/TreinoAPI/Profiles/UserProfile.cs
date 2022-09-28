using AutoMapper;
using TreinoAPI.Data.Dto.User;
using TreinoAPI.Models;

namespace TreinoAPI.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<LoginUserDto, User>();
            CreateMap<CadastroUserDto, User>();
            CreateMap<User, ReadUserDto>();
        }
    }
}

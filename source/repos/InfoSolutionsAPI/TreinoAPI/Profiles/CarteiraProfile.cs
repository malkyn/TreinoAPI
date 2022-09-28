using AutoMapper;
using TreinoAPI.Data.Dto.Carteira;
using TreinoAPI.Models;

namespace TreinoAPI.Profiles
{
    public class CarteiraProfile : Profile
    {
        public CarteiraProfile()
        {
            CreateMap<CadastroCarteiraDto, Carteira>();
        }
    }
}

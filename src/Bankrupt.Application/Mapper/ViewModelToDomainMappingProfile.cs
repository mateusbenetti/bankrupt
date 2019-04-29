using AutoMapper;
using Bankrupt.Application.Model;
using Bankrupt.Model;

namespace Bankrupt.Application.Mapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<GameResultView, BoardGameResult>();
        }
    }
}

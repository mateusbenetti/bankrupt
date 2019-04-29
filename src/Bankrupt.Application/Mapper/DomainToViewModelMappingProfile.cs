using AutoMapper;
using Bankrupt.Application.Model;
using Bankrupt.Model;

namespace Bankrupt.Application.Mapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<BoardGameResult, GameResultView>();
        }
    }
}

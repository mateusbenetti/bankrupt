using AutoMapper;
using Bankrupt.Application.ViewModel;
using Bankrupt.Domain.Model;

namespace Bankrupt.Application.Mapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<BoardGameResult, GameResultView>();
            CreateMap<BoardGameRoundRegister, GameResultRoundRegisters>();
        }
    }
}

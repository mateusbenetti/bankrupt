using AutoMapper;
using Bankrupt.Application.ViewModel;
using Bankrupt.Domain.Model;

namespace Bankrupt.Application.Mapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<GameResultView, BoardGameResult>();
            CreateMap<GameResultRoundRegisters, BoardGameRoundRegister>();
        }
    }
}

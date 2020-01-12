using Bankrupt.Data.Model.Enum;
using System;

namespace Bankrupt.Data.Model.Interface
{
    public interface IPlayerRepository : IRepository<PlayerInfo>
    {
        PlayerInfo GetPlayer(PlayerTypeEnum playerTypeEnum);
    }
}

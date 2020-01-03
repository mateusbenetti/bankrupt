using System.Collections.Generic;
using Bankrupt.Domain.Model.Enum;

namespace Bankrupt.Domain.Model.Interface
{
    public interface IPlayer
    {
        PlayerType Type { get; }
        bool WantBuy { get;  }
        int Coins { get; set; }
        BoardHouse CurrentBoardHouse { get; set; }
        bool Playing { get; set; }
        List<BoardHouse> Possessions { get; set; }
    }
}
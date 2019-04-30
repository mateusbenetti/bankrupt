using System.Collections.Generic;
using Bankrupt.Model.Enum;

namespace Bankrupt.Model.Interface
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
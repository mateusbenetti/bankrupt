using System.Collections.Generic;
using Bankrupt.Domain.Model.Enum;
using Bankrupt.Domain.Model.Interface;

namespace Bankrupt.Domain.Model
{
    public abstract class Player : IPlayer
    {
        protected Player()
        {
            Coins = 300;
            Possessions = new List<BoardHouse>();
        }
        public abstract PlayerType Type { get; }
        public abstract bool  WantBuy { get; }
        public int Coins { get; set; }
        public BoardHouse CurrentBoardHouse  { get; set; }
        public bool Playing  { get; set; }
        public List<BoardHouse> Possessions { get; set; }
    }
}
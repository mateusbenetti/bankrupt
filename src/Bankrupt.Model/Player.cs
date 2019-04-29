using System.Collections.Generic;
using Bankrupt.Model.Enum;
using Bankrupt.Model.Interface;

namespace Bankrupt.Model
{
    public abstract class Player : IPlayer
    {
        protected Player()
        {
            Coins = 300;
            Possessions = new List<BoardHouse>();
        }
        public abstract PlayerType Type { get; }
        public abstract bool  WantBuy(BoardHouse boardHouse);
        public int Coins { get; set; }
        public BoardHouse CurrentBoardHouse  { get; set; }
        public bool Playing  { get; set; }
        public List<BoardHouse> Possessions { get; set; }
    }
}
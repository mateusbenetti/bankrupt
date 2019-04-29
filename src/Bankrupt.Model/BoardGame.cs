using System.Collections.Generic;
using System.Linq;
using Bankrupt.Model.Interface;

namespace Bankrupt.Model
{
    public class BoardGame
    {
        public BoardGame(IDictionary<int, IPlayer> players, IList<BoardHouse> houses, int? maxRound)
        {
            BoardHouses = houses;
            Players = players;
            MaxRound = maxRound;
        }
        public int? MaxRound { get; set; }
        public IList<BoardHouse> BoardHouses { get; set; }
        public BoardHouse FirstBoardHouse
        {
            get { return BoardHouses.OrderBy(p => p.Sequential).First(); }
        }
        public BoardHouse LastBoardHouse
        {
            get { return BoardHouses.OrderBy(p => p.Sequential).Last(); }
        }
        public int DiceFaces { get; } = 6;
        public int CreditForRound { get; } = 100;
        public IDictionary<int, IPlayer> Players { get; set; }
        public BoardGameResult Result { get; set; }
        public int  Round  { get; set; }
    }
}
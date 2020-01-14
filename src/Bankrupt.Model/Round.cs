using Bankrupt.Domain.Model.Interface;
using System;

namespace Bankrupt.Domain.Model
{
    public class Round
    {
        public Guid GameId{ get; set; }
        public IPlayer Player { get; set; }
        public BoardGame BoardGame { get; set; }
        public BoardHouse BoardHouseAfter { get; set; }
        public BoardHouse BoardHouseBefore { get; set; }
        public string Action { get; set; }
        public int CoinsAfter { get; set; }
        public int CoinsBefore { get; set; }
    }
}
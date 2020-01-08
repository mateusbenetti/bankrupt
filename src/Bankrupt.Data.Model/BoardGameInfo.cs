using System;
using System.Collections.Generic;

namespace Bankrupt.Data.Model
{
    public class BoardGameInfo
    {
        public Guid Id { get; set; }
        public int Round { get; set; }
        public DateTime Date { get; set; }
        public PlayerInfo Winner { get; set; }
        public ICollection<BoardHouseInfo> BoardHouses { get; set; }
    }
}

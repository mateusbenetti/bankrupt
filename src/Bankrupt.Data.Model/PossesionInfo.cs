using System;

namespace Bankrupt.Data.Model
{
    public class PossesionInfo
    {
        public Guid Id { get; set; }
        public PlayerInfo Player { get; set; }
        public BoardGameInfo BoardGame { get; set; }
        public BoardHouseInfo BoardHouse { get; set; }
    }
}

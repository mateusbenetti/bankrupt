using System;
using System.Collections.Generic;
using System.Text;

namespace Bankrupt.Data.Model
{
    public class RoundRegisterInfo
    {
        public Guid Id { get; set; }
        public Guid PlayerId { get; set; }
        public PlayerInfo PlayerInfo { get; set; }
        public Guid BoardGameId { get; set; }
        public BoardGameInfo BoardGameInfo { get; set; }
        public int BoardHouseAfter { get; set; }
        public int BoardHouseBefore { get; set; }
        public string Action { get; set; }
        public int CoinsAfter { get; set; }
        public int CoinsBefore { get; set; }
    }
}
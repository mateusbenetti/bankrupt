using Bankrupt.Domain.Model.Interface;
using System;

namespace Bankrupt.Domain.Model
{
    public class BoardGameRoundRegister
    {
        public Guid BoardGameId { get; set; }
        public IPlayer Player { get; set; }
        public int BoardHouseAfter { get; set; }
        public int BoardHouseBefore { get; set; }
        public string Action { get; set; }
        public int CoinsAfter { get; set; }
        public int CoinsBefore { get; set; }
    }
}

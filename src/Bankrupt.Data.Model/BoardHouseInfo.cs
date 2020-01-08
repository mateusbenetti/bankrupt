using System;

namespace Bankrupt.Data.Model
{
    public class BoardHouseInfo
    {
        public Guid Id { get; set; }
        public int Sequential { get; set; }
        public int PurchaseValue { get; set; }
        public int RentValue { get; set; }
        public BoardGameInfo BoardGame { get; set; }
    }
}

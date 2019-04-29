using Bankrupt.Model.Enum;

namespace Bankrupt.Model
{
    public class CautiousPlayer : Player
    {
        public override PlayerType Type => PlayerType.Cautious;

        public override bool WantBuy(BoardHouse boardHouse)
        {
            var cashAfterBuy = Coins - boardHouse.PurchaseValue;
            return cashAfterBuy >= 80;
        }
    }
}
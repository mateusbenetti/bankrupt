using Bankrupt.Domain.Model.Enum;

namespace Bankrupt.Domain.Model
{
    public class CautiousPlayer : Player
    {
        public override PlayerType Type => PlayerType.Cautious;

        public override bool WantBuy
        {
            get
            {
                var cashAfterBuy = Coins - CurrentBoardHouse.PurchaseValue;
                return cashAfterBuy >= 80;
            }
        }
    }
}
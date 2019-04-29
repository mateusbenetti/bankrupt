using Bankrupt.Model.Enum;

namespace Bankrupt.Model
{
    public class DemandingPlayer : Player
    {
        public override PlayerType Type => PlayerType.Demanding;

        public override bool WantBuy(BoardHouse boardHouse)
        {
            return boardHouse.RentValue > 50;
        }
    }
}
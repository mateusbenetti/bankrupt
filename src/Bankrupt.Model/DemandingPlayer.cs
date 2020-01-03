using Bankrupt.Domain.Model.Enum;

namespace Bankrupt.Domain.Model
{
    public class DemandingPlayer : Player
    {
        public override PlayerType Type => PlayerType.Demanding;

        public override bool WantBuy => CurrentBoardHouse.RentValue > 50;
    }
}
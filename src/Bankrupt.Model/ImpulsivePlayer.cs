using System.Dynamic;
using Bankrupt.Domain.Model.Enum;

namespace Bankrupt.Domain.Model
{
    public class ImpulsivePlayer : Player
    {
        public override PlayerType Type => PlayerType.Impulsive;

        public override bool WantBuy => true;
    }
}

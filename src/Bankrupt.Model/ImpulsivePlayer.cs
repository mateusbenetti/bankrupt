using System.Dynamic;
using Bankrupt.Model.Enum;

namespace Bankrupt.Model
{
    public class ImpulsivePlayer : Player
    {
        public override PlayerType Type => PlayerType.Impulsive;

        public override bool WantBuy => true;
    }
}

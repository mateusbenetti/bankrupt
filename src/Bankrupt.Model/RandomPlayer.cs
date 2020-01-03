using System;
using Bankrupt.Domain.Model.Enum;

namespace Bankrupt.Domain.Model
{
    public class RandomPlayer : Player
    {
        private Random Random { get; }
        public RandomPlayer()
        {
            Random = new Random();
        }
        public override PlayerType Type => PlayerType.Random;
        public override bool WantBuy => Random.Next(1, 3) == 2;
    }
}
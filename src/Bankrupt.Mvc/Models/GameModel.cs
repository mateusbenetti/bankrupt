using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;

namespace Bankrupt.Mvc.Models
{
    public class GameModel
    {
        public int AmountFinishedByTimeout { get; set; }
        public int AverageRounds { get; set; }
        public IDictionary<string, int> WinsByPlayerType { get; set; }
        public  List<string>  PlayersTypeMostWinner { get; set; }
        public  int NumberOfGames { get; set; }
        public  int MaxRoundByGames { get; set; }
    }
}
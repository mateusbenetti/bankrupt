using Bankrupt.Data.Model.Enum;
using System;
using System.Collections.Generic;

namespace Bankrupt.Data.Model
{
    public class PlayerInfo
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public PlayerTypeEnum Type { get; set; }
        public ICollection<BoardGameInfo> GamesWins { get; set; }
        public ICollection<PossesionInfo> Possesions { get; set; }
    }
}

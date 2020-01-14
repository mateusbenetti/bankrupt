using Bankrupt.Domain.Model.Enum;
using System.Collections.Generic;

namespace Bankrupt.Domain.Model
{
    public class BoardGameResult
    {
        public PlayerType WinnerType { get; set; }
        public int  Rounds { get; set; }
        public bool TimeOut { get; set; }
        public List<BoardGameRoundRegister> RoundRegisters { get; set; }
    }
}
using Bankrupt.Domain.Model.Enum;

namespace Bankrupt.Domain.Model
{
    public class BoardGameResult
    {
        public PlayerType WinnerType { get; set; }
        public int  Rounds { get; set; }
        public bool TimeOut { get; set; }
    }
}
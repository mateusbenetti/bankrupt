using Bankrupt.Model.Enum;

namespace Bankrupt.Model
{
    public class BoardGameResult
    {
        public PlayerType WinnerType { get; set; }
        public int  Rounds { get; set; }
        public bool TimeOut { get; set; }
    }
}
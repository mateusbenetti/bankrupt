using System;
using System.Collections.Generic;

namespace Bankrupt.Data.Model
{
    public class BoardGameInfo
    {
        public Guid Id { get; set; }
        public int NumberRound { get; set; }
        public Guid WinnerId { get; set; }
        public PlayerInfo Winner { get; set; }
        public string RegisterCode { get; set; }
        public Guid StatisticalAnalysisId { get; set; }
        public StatisticalAnalysisInfo StatisticalAnalysis { get; set; }
        public ICollection<RoundRegisterInfo> RoundRegisters { get; set; }
    }
}

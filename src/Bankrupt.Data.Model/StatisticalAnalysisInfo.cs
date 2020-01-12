using System;
using System.Collections.Generic;
using System.Text;

namespace Bankrupt.Data.Model
{
    public class StatisticalAnalysisInfo
    {
        public Guid Id { get; set; }
        public string RegisterCode { get; set; }
        public DateTime Date { get; set; }
        public ICollection<BoardGameInfo> BoardGames { get; set; }
    }
}

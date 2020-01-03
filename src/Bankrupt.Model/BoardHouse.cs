using System;
using System.Collections.Generic;
using System.Text;
using Bankrupt.Domain.Model.Interface;

namespace Bankrupt.Domain.Model
{
   public class BoardHouse
    {
        public int Sequential { get; set; }
        public int PurchaseValue { get; set; }
        public int RentValue { get; set; }
        public IPlayer Owner { get; set; }
        public BoardHouse Next { get; set; }
    }
}
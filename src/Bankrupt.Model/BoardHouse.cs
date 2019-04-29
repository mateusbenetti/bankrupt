using System;
using System.Collections.Generic;
using System.Text;
using Bankrupt.Model.Interface;

namespace Bankrupt.Model
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
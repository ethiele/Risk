using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RiskCore
{
    public class Territory
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public List<Territory> NextTo { get; set; }
        public Continent PartOf { get; set; }
        public Player ControlledBy { get; set; }
        public int UnitCount { get; set; }
       
    }
}

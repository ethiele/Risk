using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RiskCore
{
    public class Player
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public List<Territory> TerritoriesControlled { get; set; }
    }
}

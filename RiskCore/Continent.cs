using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RiskCore
{
    public class Continent
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public List<Territory> Terriories { get; set; }
        public int Value { get; set; }
    }
}

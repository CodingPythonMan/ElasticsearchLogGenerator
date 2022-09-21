using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElasticSearchProject
{
    public class BaseLog
    {
        [Text(Name = "Kennen")]
        public long Kennen { get; set; }
        [Text(Name = "TM")]
        public string TM { get; set; }
    }

    public class Custom1Log : BaseLog
    {
        public List<int> Characters { get; set; }
    }

    public class Custom2Log : BaseLog
    {
        public Dictionary<int, int> Characters { get; set; }
    }

    public class Custom3Log : BaseLog
    {
        public int[] Characters { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DB.Web.Models
{
    public class HomeModels
    {
        //public string iconCls { get; set; } = "display:none";
        public string text { get; set; }
        public bool leaf { get; set; }
        public string data { get; set; }
        public List<HomeChildren> children { get; set; }
    }
    public class HomeChildren
    {
        //public string iconCls { get; set; } = "display:none";
        public Guid id { get; set; }
        public bool leaf { get; set; }
        public string text { get; set; }
        public string url { get; set; }
    }
}

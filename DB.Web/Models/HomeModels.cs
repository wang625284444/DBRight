using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DB.Web.Models
{
    public class HomeModels
    {
        public Guid id { get; set; }
        public string title { get; set; }
        public string icon { get; set; } = "&#xe61c;";
        public bool spread { get; set; } = false;
        public string href { get; set; }
        public List<HomeChildren> children { get; set; }
    }
    public class HomeChildren
    {
        public Guid id { get; set; }
        public string icon { get; set; } = "&#xe61c;";
        public bool spread { get; set; } = false;
        public string title { get; set; }
        public string href { get; set; }
    }
}

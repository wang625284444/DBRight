using System;
using System.Collections.Generic;

namespace DB.Web.Models
{
    public class ModuleModels
    {
        public bool @checked { get; set; }
        public string text { get; set; }
        public bool leaf { get; set; }
        public string data { get; set; }
        public List<ModuleChildren> children { get; set; }
    }
    public class ModuleChildren
    {
        public Guid id { get; set; }
        public bool @checked { get; set; }
        public bool leaf { get; set; }
        public string text { get; set; }
        public string url { get; set; }
    }
}
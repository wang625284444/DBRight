using System;
using System.Collections.Generic;

namespace DB.Web.Models
{
    public class TreeModels
    {
        //public Guid id { get; set; }
        //public Guid parentId { get; set; }
        public string text { get; set; }
        public bool leaf { get; set; }
        public string data { get; set; }
        public List<Children> children { get; set; }
    }
    public class Children
    {
        public Guid id { get; set; }
        public bool leaf { get; set; }
        public string text { get; set; }
        public string url { get; set; }
    }
    public class Attributes
    {
    }
}
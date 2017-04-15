using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace COP_4710_College_App.Models
{
    public class SchoolViewModel
    {
        public int id { get; set; }
        public string name { get; set; }
        public int createDate { get; set; }
        public int createTime { get; set; }
        public string address { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
    }
}
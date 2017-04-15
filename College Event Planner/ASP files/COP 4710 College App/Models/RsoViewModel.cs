using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace COP_4710_College_App.Models
{
    public class RsoViewModel
    {
        public int id { get; set; }
        public string name { get; set; }
        public int schoolNameId { get; set; }
        public int typeId { get; set; }
        public string contactName { get; set; }
        public string contactPhone { get; set; }
        public string contactEmail { get; set; }
        public string description { get; set; }
        public int memberId { get; set; }
    }
}
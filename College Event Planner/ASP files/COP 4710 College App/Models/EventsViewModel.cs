using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace COP_4710_College_App.Models
{
    public class EventsViewModel
    {

        public int id { get; set; }
        public string name { get; set; }
        public int createDate { get; set; }
        public int createTime { get; set; }
        public string description { get; set; }
        public int categoryId { get; set; }
        public int time { get; set; }
        public int date { get; set; }
        public string location { get; set; }
        public string contactPhone { get; set; }
        public string contactEmail { get; set; }
        public int privacyId { get; set; }
        public int schoolNameId { get; set; }
        public int rsoNameId { get; set; }
        public string comments { get; set; }
        public string rating { get; set; }

    }
}
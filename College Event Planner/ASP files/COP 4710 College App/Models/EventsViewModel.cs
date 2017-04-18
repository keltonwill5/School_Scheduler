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
        public DateTime createDate { get; set; }
        public string description { get; set; }
        public int categoryId { get; set; }
        public DateTime time { get; set; }
        public string location { get; set; }
        public string contactPhone { get; set; }
        public string contactEmail { get; set; }
        public int privacyId { get; set; }
        public int schoolNameId { get; set; }
        public int rsoNameId { get; set; }
        public string comments { get; set; }
        public string rating { get; set; }
        public string rsoName { get; set; }
        public string category { get; set; }
        public string schoolName { get; set; }

    }
}
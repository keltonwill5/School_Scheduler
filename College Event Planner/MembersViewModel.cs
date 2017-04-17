using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace COP_4710_College_App.Models
{
    public class MembersViewModel
    {
        public int id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string picture { get; set; }
        public DateTime createDate { get; set; }
        public DateTime createTime { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public int schoolNameId { get; set; }
        public int userTypeId { get; set; }
        public string schoolName { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace COP_4710_College_App.Models
{

    

    public class SessionHandler
    {
        public MembersViewModel Cur_user = new MembersViewModel();

        public static bool tryLogin(string email, string pass)
        {

            return true;
        }
        public static bool login()
        {
           

            return true;

        }

        public static bool trySignup(string email, string pass)
        {

            return true;
        }

        public static bool signup()
        {


            return true;

        }



        public static bool loggedIn()
        {


            /* if (HttpContext.Current.Session["loggedIn"] == null)
                 return false;
             else if ((bool)HttpContext.Current.Session["loggedIn"] == true)
                 return true; 


             return false; */
            return true;
        }


    }
}
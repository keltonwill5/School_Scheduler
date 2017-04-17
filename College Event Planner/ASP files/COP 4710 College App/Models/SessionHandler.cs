using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace COP_4710_College_App.Models
{

    

    public class SessionHandler
    {
        
        public static bool loggedIn()
        {


            if (HttpContext.Current.Session["loggedIn"] == null)
                 return false;
             else if ((bool)HttpContext.Current.Session["loggedIn"] == true)
                 return true; 


             return false; 
          
        }

        public static bool userAllowed(int page)
        {
            if (HttpContext.Current.Session["privilegeID"] == null)
                return false;
            else if ((int)HttpContext.Current.Session["privilegeID"] >= page)
                return true;


            return false;


        }


    }
}
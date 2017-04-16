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


    }
}
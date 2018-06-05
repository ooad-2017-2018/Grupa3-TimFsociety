using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eTutorMVC.Models
{
    public class Password
    {
        public int password_id { get; set; }
        public int user_id { get; set; }
        public string password1 { get; set; }
    }
}
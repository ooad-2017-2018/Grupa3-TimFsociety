using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eTutorMVC.Models
{
    public class User
    {
        public int user_id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string e_mail { get; set; }
        public string pay_pal_mail { get; set; }
        public Nullable<float> e_coin_total { get; set; }
        public string type { get; set; }
    }
}
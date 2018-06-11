using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eTutorMVC.Models
{
    public class Notification
    {
        public int notification_id { get; set; }
        public int user_id { get; set; }
        public string content { get; set; }
        public string priority { get; set; }
        public string date_time { get; set; }
    }
}
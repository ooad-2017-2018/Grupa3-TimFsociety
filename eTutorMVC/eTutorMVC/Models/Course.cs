using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eTutorMVC.Models
{
    public class Course
    {
        public int course_id { get; set; }
        public int tutor_id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string category { get; set; }
        public float price_e_coin { get; set; }
    }
}
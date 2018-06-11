using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eTutorMVC.Models
{
    public class Tutor
    {
        public int tutor_id { get; set; }
        public Nullable<float> rating { get; set; }
        public string qualifications { get; set; }
    }
}
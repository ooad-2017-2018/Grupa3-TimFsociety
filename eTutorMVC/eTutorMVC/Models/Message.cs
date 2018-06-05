using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eTutorMVC.Models
{
    public class Message
    {
        public int message_id { get; set; }
        public int sender_id { get; set; }
        public int reciever_id { get; set; }
        public string message_content { get; set; }
        public string subject { get; set; }
        public bool seen { get; set; }
    }
}
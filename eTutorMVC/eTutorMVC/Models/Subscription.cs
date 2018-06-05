using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eTutorMVC.Models
{
    public class Subscription
    {
        public int subscription_id { get; set; }
        public string subscription_type { get; set; }
        public float subscription_price { get; set; }
        public float e_coin_amount { get; set; }
        public string date_time_next_payment { get; set; }
    }
}
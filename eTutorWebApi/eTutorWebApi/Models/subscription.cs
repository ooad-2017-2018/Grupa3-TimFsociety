//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace eTutorWebApi.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class subscription
    {
        public int subscription_id { get; set; }
        public string subscription_type { get; set; }
        public float subscription_price { get; set; }
        public float e_coin_amount { get; set; }
        public string date_time_next_payment { get; set; }
    }
}
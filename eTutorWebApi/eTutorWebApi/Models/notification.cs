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
    
    public partial class notification
    {
        public int notification_id { get; set; }
        public int user_id { get; set; }
        public string content { get; set; }
        public string priority { get; set; }
        public string date_time { get; set; }
    }
}
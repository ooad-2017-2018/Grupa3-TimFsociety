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
    
    public partial class message
    {
        public int message_id { get; set; }
        public int sender_id { get; set; }
        public int reciever_id { get; set; }
        public string message_content { get; set; }
        public string subject { get; set; }
        public bool seen { get; set; }
    }
}

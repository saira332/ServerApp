//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Server.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class notification
    {
        public int id { get; set; }
        public string title { get; set; }
        public string type { get; set; }
        public string status { get; set; }
        public Nullable<int> admin_id { get; set; }
        public Nullable<int> accepter_id { get; set; }
        public Nullable<int> donor_id { get; set; }
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace project_finall.Models.Database
{
    using System;
    using System.Collections.Generic;
    
    public partial class decentralization
    {
        public string Username { get; set; }
        public string Id_Mission { get; set; }
        public string Note { get; set; }
    
        public virtual Account Account { get; set; }
        public virtual Mission Mission { get; set; }
    }
}

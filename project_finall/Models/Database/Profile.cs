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
    
    public partial class Profile
    {
        public string Surname { get; set; }
        public string Middle_Name { get; set; }
        public string Name { get; set; }
        public Nullable<bool> Sex { get; set; }
        public string P_Number { get; set; }
        public string Email { get; set; }
        public Nullable<bool> STATUS { get; set; }
        public string Note { get; set; }
        public string Username { get; set; }
    
        public virtual Account Account { get; set; }
    }
}

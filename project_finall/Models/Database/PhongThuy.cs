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
    
    public partial class PhongThuy
    {
        public int Id_PhongThuy { get; set; }
        public string Name_PhongThuy { get; set; }
        public string Img { get; set; }
        public string Summary_Content { get; set; }
        public Nullable<System.DateTime> Date_Submitted { get; set; }
        public string Content { get; set; }
        public string Account { get; set; }
        public Nullable<bool> DADUYET { get; set; }
        public Nullable<bool> Show_Home { get; set; }
    
        public virtual Account Account1 { get; set; }
    }
}

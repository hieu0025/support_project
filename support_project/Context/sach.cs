//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace support_project.Context
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class sach
    {
        public int id_sach { get; set; }
        public string ten_sach { get; set; }
        public string tac_gia { get; set; }
        public string nxb { get; set; }
        public string duong_dan { get; set; }
        public string anh { get; set; }
        public string mo_ta { get; set; }
        public Nullable<int> id_khoa { get; set; }
    
        public virtual khoa khoa { get; set; }
        [NotMapped]
        public System.Web.HttpPostedFileBase ImageUpload { get; set; }
        public System.Web.HttpPostedFileBase FileUpload { get; set; }
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     這個程式碼是由範本產生。
//
//     對這個檔案進行手動變更可能導致您的應用程式產生未預期的行為。
//     如果重新產生程式碼，將會覆寫對這個檔案的手動變更。
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApplication1.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Cwma
    {
        public int Id { get; set; }
        public string Department { get; set; }
        public string Applicant { get; set; }
        public Nullable<System.DateTime> MyDate { get; set; }
        public Nullable<System.DateTime> StartDay { get; set; }
        public Nullable<System.DateTime> EndDay { get; set; }
        public Nullable<System.DateTime> Mytime1 { get; set; }
        public Nullable<System.DateTime> Mytime2 { get; set; }
        public string Purpose { get; set; }
        public string ApplicantMatter { get; set; }
        public string AssistanceMatter { get; set; }
        public string Description { get; set; }
        public string Fid { get; set; }
        public int Status { get; set; }
    }
}

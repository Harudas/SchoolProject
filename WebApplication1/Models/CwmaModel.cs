using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class CwmaModel
    {
        public DateTime? StartDay { get; set; }

        public DateTime? EndDay { get; set; }

        public String Department { get; set; }

        public String Applicant { get; set; }
        public DateTime? MyDate { get; set; }

        public DateTime? Mytime1 { get; set; }
        public DateTime? Mytime2 { get; set; }

        public String Purpose { get; set; }

        public String checkbox0 { get; set; }
        public String checkbox1 { get; set; }
        public String Description { get; set; }
    }
}
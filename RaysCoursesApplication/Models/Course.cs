using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace RaysCoursesWebAPI.Models
{
    public partial class Course
    {
        public int Cid { get; set; }
        public int UniRefId { get; set; }
        public string Cname { get; set; }
        public string Cfaculty { get; set; }
        public string Ccategory { get; set; }
        public DateTime? CdateOfIntake { get; set; }
        public string Cyears { get; set; }
        public decimal? Cfee { get; set; }

        public virtual University UniRef { get; set; }
    }
}

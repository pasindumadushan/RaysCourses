using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RaysCoursesApplication.Models
{
    public class CourseViewModel
    {
        public int Cid { get; set; }
        public int UniId { get; set; }
        public string UniName { get; set; }
        public string Cname { get; set; }
        public DateTime? CdateOfIntake { get; set; }
        public string Cyears { get; set; }
        public decimal? Cfee { get; set; }
        public string UniImgPath { get; set; }
    }
}

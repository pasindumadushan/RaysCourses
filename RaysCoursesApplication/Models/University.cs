using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace RaysCoursesWebAPI.Models
{
    public partial class University
    {
        public University()
        {
            Course = new HashSet<Course>();
        }

        public int UniId { get; set; }
        public string UniName { get; set; }
        public string UniAddr { get; set; }
        public string UniPnum { get; set; }
        public string UniImgPath { get; set; }

        public virtual ICollection<Course> Course { get; set; }
    }
}

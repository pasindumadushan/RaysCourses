using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace RaysCoursesWebAPI.Models
{
    public partial class User
    {
        public int Uid { get; set; }
        public string Uname { get; set; }
        public string Umail { get; set; }
        public string Upassword { get; set; }
        public string Uaddress { get; set; }
        public string UphoneNo { get; set; }
    }
}

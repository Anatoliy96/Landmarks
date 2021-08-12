using System;
using System.Collections.Generic;
using System.Text;

namespace LandmarkDAL.Models
{
    class Users : Common
    {
        public string UserName { get; set; }
        public int Password { get; set; }
        public string Email { get; set; }
        public string City { get; set; }
        public DateTime BirthDate { get; set; }
    }
}

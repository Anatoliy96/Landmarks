using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace LandmarkDAL.Models.User
{
    class UserRollMappings : Common
    {
        [ForeignKey("UserID")]

        public int UserID { get; set; }

        [ForeignKey("RoleID")]

        public int RoleID { get; set; }
    }
}

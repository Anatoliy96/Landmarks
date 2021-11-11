using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandmarkDAL.Models.Users
{
    public class UserRoleMapping : Common
    {
        [ForeignKey("UserID")]
        public int UserID { get; set; }

        [ForeignKey("RoleID")]

        public int RoleID { get; set; }
    }
}

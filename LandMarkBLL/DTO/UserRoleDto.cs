using LandmarkDAL.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandMarkBLL.DTO
{
   public class UserRoleDto : IDto
    {
        public List<Role> Roles { get; set; }
    }
}

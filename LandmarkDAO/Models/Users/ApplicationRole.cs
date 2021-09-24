using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandmarkDAL.Models.Users
{
  public class ApplicationRole : IdentityRole<Guid>
    {

        public ApplicationRole(string roleName) : base(roleName) { }
        public ApplicationRole() : base() { }
    }
}

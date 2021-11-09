using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandmarkDAL.Models.Users
{
    public class RegisterTokens : Common
    {
        [ForeignKey("UserID")]
        public int UserID { get; set; }

        public string Token { get; set; }

        public DateTime Generated_token { get; set; }

        public DateTime? Confirmed { get; set; }
    }
}

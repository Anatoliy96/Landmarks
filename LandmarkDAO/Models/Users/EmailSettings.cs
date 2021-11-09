using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace LandmarkDAL.Models.Users
{
   public class EmailSettings : Common
    {

        const string Email = "buhalkoch@gmail.com";
        const string Password = "kgfdfqxfrfbxtirv";
        const string EmailServer = "smtp.gmail.com";
        const int Port = 587;
        const string sender = "buhalkoch@gmail.com";


        public string Sender {
            get
            {
                return sender;
            }
        }


        NetworkCredential EmailCredentials { 
            get
            {
                return new NetworkCredential(Email, Password);
            }
        }

        public SmtpClient MailClient
        {
            get
            {
                return new SmtpClient(EmailServer)
                {
                    Port = Port,
                    Credentials = EmailCredentials,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Timeout = 20000
                };
            }
        }
    }
}

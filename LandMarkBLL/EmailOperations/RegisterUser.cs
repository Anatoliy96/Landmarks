using LandmarkDAL.DAO;
using LandmarkDAL.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace LandMarkBLL.EmailOperations
{
    public class RegisterUser
    {
        string conformationActionLink = "https://localhost:44331/Account/ConfirmUser";
        public void SendConfirmationEmail(string ReceiverEmail, string Subject, string Body)
        {
            EmailSettings emailSettings = new EmailSettings();
            SmtpClient client = emailSettings.MailClient;

            MailMessage message = new MailMessage(emailSettings.Sender, ReceiverEmail);

            message.Subject = Subject;

            message.Body = Body;

            client.Send(message);
        }

        public void InitialRegistration(string UserName, string Email, string Password)
        {
            // Generate token
            TokenGenerator tokenGenerator = new TokenGenerator();
            string token = tokenGenerator.GenerateToken(UserName, Email);
            // Compose link
            string link = conformationActionLink + "?token=" + token;
            // Compose letter
            string subject = "Confirm Registration";
            StringBuilder letterBody = new StringBuilder();
            letterBody.Append("Confirmation Link:\n");
            letterBody.Append(link);
            // Send Letter
            SendConfirmationEmail(Email, subject, letterBody.ToString());
            // Insert user
            UserBLL userBLL = new UserBLL();
            userBLL.RegisterUser(
                userBLL.Username = UserName,
                userBLL.Password = Password,
                null,
                userBLL.Email = Email);
            // Insert Token
            UsersDAO userDao = new UsersDAO();
            Users newUser = userDao.GetByUserName(UserName);
            InsertToken(newUser.ID, token, DateTime.Now, null);

        }
        public void InsertToken(int UserID, string Token, DateTime Generated_token, DateTime? Confirmed)
        {
            TokenBLL tokenBLL = new TokenBLL();
            tokenBLL.RegisterToken(
                UserID,
                Token,
                Generated_token,
                Confirmed);
        }
    }
}

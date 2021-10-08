using LandMarkBLL;
using LandmarkDAL.Models.Users;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace LandmarksPresentation.Controllers
{
    public class AccountController : Controller
    {

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]

        public IActionResult Login([Bind] LoginModel users)
        {
            LandmarkDAL.DAO.Context.LandmarkContext context = new LandmarkDAL.DAO.Context.LandmarkContext();
            var userFromBase = context.Users.FirstOrDefault(u => u.Username == users.Username);
            if (userFromBase != null && PasswordHash.Verify(users.Password, userFromBase.Password))
            {
                var userClaims = new List<Claim>()
                {
                new Claim(ClaimTypes.Name, users.Username),
                new Claim(ClaimTypes.Email, "Anatoliy@test.com"),
                 };

                var AnatoliyIdentity = new ClaimsIdentity(userClaims, "User Identity");

                var userPrincipal = new ClaimsPrincipal(new[] { AnatoliyIdentity });
                HttpContext.SignInAsync(userPrincipal);

                return RedirectToAction("Index", "Home");
            }
            return View(users);
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Home");

        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register([Bind] Users model)
        {
            LandmarkDAL.DAO.Context.LandmarkContext landmarkContext = new LandmarkDAL.DAO.Context.LandmarkContext();
            var UserExists = landmarkContext.Users.Where(u => u.Username.Equals(model.Username)).SingleOrDefault();
            if (UserExists != null)
            {
                ViewBag.Error = "This user is already registered.";
                return View();
            }
            else
            {
                UserBLL userBLL = new UserBLL();
                userBLL.RegisterUser(
                    userBLL.Username = model.Username,
                    userBLL.Password = model.Password,
                    userBLL.ConfirmPassword = model.ConfirmPassword);
            }
            return RedirectToAction("Login","Account");
        }
    }
}

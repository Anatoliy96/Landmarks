using LandMarkBLL;
using LandMarkBLL.DTO;
using LandMarkBLL.EmailOperations;
using LandmarkDAL.Models.Users;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
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

                UserBLL userBLL = new UserBLL();
                UserRoleDto roleDto = new UserRoleDto();
                roleDto = userBLL.GetUserRoles(users.Username);

                foreach (Role r in roleDto.Roles)
                {
                    userClaims.Add(new Claim(ClaimTypes.Role, r.RoleName));
                }

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
                RegisterUser registerUser = new RegisterUser();
                registerUser.InitialRegistration(model.Username, model.Email, model.Password);
            }
            return RedirectToAction("Login","Account");
        }

        public IActionResult ConfirmUser(string Token)
        {
            TokenBLL tokenBLL = new TokenBLL();
            try
            {
                tokenBLL.ConfirmToken(Token);
                ViewBag.Confirmed = true;
            }
            catch(Exception ex)
            {
                ViewBag.Confirmed = false; 
            }

            return View();
        }
    }
}

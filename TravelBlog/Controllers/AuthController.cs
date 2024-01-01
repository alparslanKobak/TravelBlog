using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using TravelBlog.Entity.Abstract;
using TravelBlog.Models;

namespace TravelBlog.Controllers
{
    public class AuthController : Controller
    {
        private readonly IAppUserCrud _appUserCrud;

        public AuthController(IAppUserCrud appUserCrud)
        {
            _appUserCrud = appUserCrud;
        }



        // GET: Auth/Login
        public ActionResult Login()
        {
            return View();
        }

        // POST: Auth/Login
        [HttpPost]
        public ActionResult Login(UserViewModel viewModel)
        {
            try
            {
                AppUser appUser = _appUserCrud.GetUserByInclude(u => u.Email == viewModel.Email && u.Password == viewModel.Password);
                if (appUser != null)
                {
                    Session["User"] = appUser;

                    List<Claim> claims = new List<Claim>()
                    {
                        new Claim(ClaimTypes.Email, appUser.Email),
                        new Claim(ClaimTypes.Role, appUser.RoleId == 1 ? "Admin" : "Blogger")
                    };

                    ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, "Login");

                    ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

                    HttpContext.User = claimsPrincipal;


                    FormsAuthentication.SetAuthCookie(appUser.Email, true);
                    

                    TempData["Message"] = "<div class='alert alert-success text-center'>Login Success </div> ";

                    return RedirectToAction("Index", "Blogger");
                }
                else
                {
                    TempData["Message"] = "<div class='alert alert-danger text-center'>Email or Password is wrong </div> ";

                    return View();
                }


            }
            catch (Exception e)
            {
                TempData["Message"] = $"<div class='alert alert-danger text-center'>An error happened : {e.Message} </div> ";
                return View();
            }
        }


        // GET: Auth/Register
        public ActionResult Register()
        {
            return View();
        }

        // POST: Auth/Register
        [HttpPost]
        public ActionResult Register(AppUser viewModel)
        {
            try
            {
                AppUser appUser = new AppUser()
                {
                    Email = viewModel.Email,
                    Password = viewModel.Password,
                    RoleId = 2,
                    UserName = viewModel.UserName
                };

                _appUserCrud.Add(appUser);

                TempData["Message"] = "<div class='alert alert-success text-center'>Register Success </div> ";

                return RedirectToAction("Login");
            }
            catch (Exception e)
            {
                TempData["Message"] = $"<div class='alert alert-danger text-center'>An error happened : {e.Message} </div> ";
                return View();
            }
        }

        // GET: Auth/Logout
        public ActionResult Logout()
        {
            Session["User"] = null;
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }


    }
}

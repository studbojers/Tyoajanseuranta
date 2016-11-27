using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tyoajanseuranta5.Models;

namespace Tyoajanseuranta5.Controllers
{
    public class UserAccountController : Controller
    {
        // GET: UserAccount
        public ActionResult Index()
        {
            return RedirectToAction("Login");
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(UserAccount account)
        {
            if(ModelState.IsValid)
            {
                using (TyoajanseurantaDbContext db = new TyoajanseurantaDbContext())
                {
                    db.userAccount.Add(account);
                    db.SaveChanges();
                }
                ModelState.Clear();
                ViewBag.Message = "Registration successful!";
                return RedirectToAction("RegistrationSucceeded");
            }
            return View();
        }

        public ActionResult Login()
        {
            if (Session["UserID"] != null)
                return RedirectToAction("../Workinghours/LoggedIn");

            return View();
        }

        [HttpPost]
        public ActionResult Login(UserAccount user)
        {            
            using (TyoajanseurantaDbContext db = new TyoajanseurantaDbContext())
            {
                var usr = db.userAccount.Where(u => u.Username == user.Username &&
                        u.Password == user.Password).FirstOrDefault();
                if(usr != null)
                {
                    Session["UserID"] = usr.UserID.ToString();
                    Session["Username"] = usr.Username.ToString();
                    return RedirectToAction("../Workinghours/LoggedIn");
                }
                else
                {
                    ModelState.AddModelError("", "Login Failed.");
                }
            }
            return View();
        }

        /*
        public ActionResult LoggedIn()
        {
            if (Session["UserID"] != null)
                return View();
            else
                return RedirectToAction("Login");
        }
        */

        public ActionResult LoggedOut()
        {
            if (Session["UserID"] != null)
            {
                Session.Clear();
            }

            return RedirectToAction("Login");
        }

        public ActionResult RegistrationSucceeded()
        {
            return View();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tyoajanseuranta5.Models;

namespace Tyoajanseuranta5.Controllers
{
    public class WorkinghoursController : Controller
    {
        public ActionResult LoggedIn()
        {
            if (Session["UserID"] != null)
                return View();
            else
                return RedirectToAction("../UserAccount/Login");
        }

        public ActionResult AddStartTime()
        {
            if (Session["UserID"] != null)
            { 
                Workinghours hours = new Workinghours();
                hours.UserID = int.Parse(Session["UserID"].ToString());
                hours.DateTime = DateTime.Now;
                hours.Direction = 1; // in
                hours.Reason = 0;

                using (TyoajanseurantaDbContext db = new TyoajanseurantaDbContext())
                {
                    db.workinghours.Add(hours);
                    db.SaveChanges();
                    ViewBag.Message = "IN: " + hours.DateTime.ToString("yyyy-MM-dd HH:mm");
                    return View();
                }
            }
            return RedirectToAction("../UserAccount/Login");

        }

        public ActionResult AddEndTime()
        {
            if (Session["UserID"] != null)
            {
                Workinghours hours = new Workinghours();
                hours.UserID = int.Parse(Session["UserID"].ToString());
                hours.DateTime = DateTime.Now;
                hours.Direction = 0; // out
                hours.Reason = 0;

                using (TyoajanseurantaDbContext db = new TyoajanseurantaDbContext())
                {
                    db.workinghours.Add(hours);
                    db.SaveChanges();
                    ViewBag.Message = "OUT: " + hours.DateTime.ToString("yyyy-MM-dd HH:mm");
                    return View();
                }
            }
            return RedirectToAction("../UserAccount/Login");
        }
    }
}
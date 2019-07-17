using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FYP.EntityFramework;
using FYP.Models;

namespace FYP.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(Accounts acc)
        {
            if(ModelState.IsValid)
            {
                var db = new ConstructionEntities();
                var row = new Users();
                row.Username=acc.Username;
                row.Password = acc.Password;
                row.ConfirmPass = acc.ConfirmPass;
                row.FirstName = acc.FirstName;
                row.LastName = acc.LastName;
                row.Email = acc.Email;
                row.Phone = acc.Phone;
                //row.Admin = false;
                db.Users.Add(row);
                var rowsCount = db.SaveChanges();
                ModelState.Clear();
                Session["userId"] = row.Id.ToString();
                Session["user"] = row.Username.ToString();
                return RedirectToAction("Welcome", "Home");

                //ViewBag.Message = acc.Username + " has been successfully registered";

                // return Redirect("/home/index");
            }
            return View(acc);
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Accounts user)
        {
            //using (MyDbContext db = new MyDbContext())
            //{
                var context = new ConstructionEntities();
                var row = new Users();
                row = context.Users.Where(u => u.Username == user.Username).Where(u => u.Password == user.Password).FirstOrDefault();
                if (row != null)
                {
                    Session["userId"] = row.Id.ToString();
                    Session["user"] = row.Username.ToString();
                    return RedirectToAction("Welcome", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Username or Password is incorrect");
                }
                return View();
            //}
        }

        public ActionResult LoggedIn()
        {
            if(Session["userId"] != null)
            {
                return View();

            }else
            {
                return View();
                
            }
        }
    }
}
using FYP.EntityFramework;
using FYP.Models;
using FYP.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FYP.Controllers
{
    public class ReferenceController : Controller
    {
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public ActionResult Reference()
        {


            //this will return 1 row from db with id 0f 2
            var context = new ConstructionEntities();
            var container = new Reference();
            container = context.Reference.Where(m => m.Id == 1).FirstOrDefault();

            //this will return multiple rows eg dispaly all users in the company
            var listOfRefs = new List<Reference>();
            listOfRefs = context.Reference.ToList();
          


            var vm = new RefVM();
            vm.list = listOfRefs;



            return View(vm);
        }

        [HttpPost]
        public ActionResult Reference(References rf)
        {
            var DbContext = new ConstructionEntities();
            var row = new Reference();

            row.Reference1 = rf.Reference;
            row.Referee = rf.Referee;

            DbContext.Reference.Add(row);
            var rowsCount = DbContext.SaveChanges();

            return RedirectToAction("Reference", "Reference");
        }
    }
}
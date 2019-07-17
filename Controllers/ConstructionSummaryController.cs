using FYP.EntityFramework;
using FYP.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FYP.Controllers
{
    public class ConstructionSummaryController : Controller
    {
        // GET: ConstructionSummary
        [HttpGet]
        public ActionResult ConstructionBuilderSummary()
        {
            var context = new ConstructionEntities();
            var row = new ConstructionPrice();
            int UserVal = Convert.ToInt32(Session["userId"]);
            row = context.ConstructionPrice.Where(m => m.UserId == UserVal).FirstOrDefault();

            //this will return multiple rows eg dispaly all users in the company
            var listOfQuotes = new List<ConstructionPrice>();
            listOfQuotes = context.ConstructionPrice.Where(m => m.UserId == UserVal).ToList();

            var vm = new TestVM();
            vm.list = listOfQuotes;
            //vm.OneQuote = row;
            //vm.NoDoors = row.NoDoors;
            //vm.NoWindows = row.NoWindows;



            return View(vm);
        }
    }
}
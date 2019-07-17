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
    public class ConstructionController : Controller
    {
        // GET: ConWork/Construction
        [HttpGet]
        public ActionResult ConstructionBuilder()
        {


            //this will return 1 row from db with id 0f 2
            var context = new ConstructionEntities();
            var container = new ConstructionPrice();
            container = context.ConstructionPrice.Where(m => m.Id == 2).FirstOrDefault();

            //this will return multiple rows eg dispaly all users in the company
            var listOfQuotes = new List<ConstructionPrice>();
            listOfQuotes = context.ConstructionPrice.ToList();


            var vm = new ConWork();



            return View(vm);
        }

        public ActionResult playtime()
        {
            var context = new ConstructionEntities();
            var container = new ConstructionPrice();
            //this will return multiple rows eg dispaly all users in the company
            var listOfQuotes = new List<ConstructionPrice>();
            listOfQuotes = context.ConstructionPrice.ToList();

            var vm = new TestVM();
            vm.list = listOfQuotes;
            return View(vm);
        }


        [HttpPost]
        public ActionResult ConstructionBuilder(ConWork vm)
        {

            var DbContext = new ConstructionEntities();
            var row = new ConstructionPrice();

            decimal DemCostPrice = 50;
            decimal SiteClearCost = 50;
            vm.PreConTotal = (vm.DemMetre * DemCostPrice) + (vm.SiteClearMetre * SiteClearCost);

            decimal SubStruc = 120;
            vm.StructureCost = (vm.FloorLength * SubStruc) * vm.Stories;
            decimal BuildSize = vm.FloorLength * vm.Stories;


            decimal Walls;
            //int Roof = 100;
            if(vm.ExternalWall == "brick")
            {
                Walls = 450 * BuildSize;
            }else if(vm.ExternalWall == "stone")
            {
                Walls = 500 * BuildSize;
            }else if(vm.ExternalWall == "wood")
            {
                Walls = 325 * BuildSize;
            }else
            {
                Walls = 0;
            }
            vm.SuperStructCost = Walls; //+ (Roof + vm.RoofStructure);


            decimal door = 400;
            decimal window = 600;
            decimal Rooftiles;
            if(vm.RoofTiles == "crt")
            {
                Rooftiles = 500 * vm.FloorLength;
            }else if(vm.RoofTiles == "nsrt")
            {
                Rooftiles = 700 * vm.FloorLength;
            }else if(vm.RoofTiles == "crt2")
            {
                Rooftiles = 550 * vm.FloorLength;
            }else if(vm.RoofTiles == "asrt")
            {
                Rooftiles = 400 * vm.FloorLength;
            }else
            {
                Rooftiles = 0;
            }
            vm.ExternalCost = (door * vm.NoDoors) + (window * vm.NoWindows) + Rooftiles;

            decimal plumbingCost;
            decimal heatingCost;
            decimal electricCost;
            decimal plasteringCost;
            decimal decorCost;

            if (vm.Plumbing == true)
            {
                plumbingCost = 100 * BuildSize;

            }else
            {
                plumbingCost = 0;
            }

            if (vm.Heating == true)
            {
                heatingCost = 100 * BuildSize;

            }else
            {
                heatingCost = 0;
            }

            if (vm.Electrics == true)
            {
                electricCost = 100 * BuildSize;

            }else
            {
                electricCost = 0;
            }

            if (vm.Plastering == true)
            {
                plasteringCost = 100 * BuildSize;

            }else
            {
                plasteringCost = 0;
            }

            if (vm.Decor == true)
            {
                decorCost = 100 * BuildSize;

            }else
            {
                decorCost = 0;
            }

            decimal PatioCost = 50;
            decimal DriveWayCost = 50;
            vm.ServicesCost = plumbingCost + heatingCost + electricCost + plasteringCost + decorCost + (PatioCost * vm.PatioMetre) + (DriveWayCost * vm.DriveWayMetre);
            

            vm.Extra = 250 * BuildSize;
            vm.TotalCost = vm.PreConTotal + vm.StructureCost + vm.SuperStructCost + vm.ExternalCost + vm.ServicesCost + vm.Extra;



            row.Demolition = vm.Demolition;
            row.DemMetre = vm.DemMetre;
            row.SiteClear = vm.SiteClear;
            row.SiteClearMetre = vm.SiteClearMetre;
            row.PreConTotal = vm.PreConTotal;
            row.Stories = vm.Stories;
            row.FloorLength = vm.FloorLength;
            row.StructureCost = vm.StructureCost;
            row.ExternalWall = vm.ExternalWall;
            row.RoofStructure = vm.RoofStructure;
            row.SuperStructCost = vm.SuperStructCost;
            row.RoofTiles = vm.RoofTiles;
            row.NoDoors = vm.NoDoors;
            row.NoWindows = vm.NoWindows;
            row.ExternalCost = vm.ExternalCost;
            row.Plumbing = vm.Plumbing;
            row.Heating = vm.Heating;
            row.Electrics = vm.Electrics;
            row.Plastering = vm.Plastering;
            row.Decor = vm.Decor;
            row.Patio = vm.Patio;
            row.PatioMetre = vm.PatioMetre;
            row.DriveWay = vm.DriveWay;
            row.DriveWayMetre = vm.DriveWayMetre;
            row.ServicesCost = vm.ServicesCost;
            row.Extra = vm.Extra;
            row.TotalCost = vm.TotalCost;

            int UserVal = Convert.ToInt32(Session["userId"]);
            row.UserId = UserVal;

            DbContext.ConstructionPrice.Add(row);
            var rowsCount = DbContext.SaveChanges();
       

            return RedirectToAction("ConstructionBuilderSummary","ConstructionSummary");

            //return View(vm);
        }

        public ActionResult ConstructionBuilderSummary(ConWork vm)
        {
            return View(vm);
        }


        //public ActionResult Index(ConWork model, string command)
        //{

        //}
    }
}
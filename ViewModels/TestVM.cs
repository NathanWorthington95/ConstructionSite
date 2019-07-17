using FYP.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FYP.ViewModels
{
    public class TestVM
    {
        public IEnumerable<ConstructionPrice> list { get; set; }
        public ConstructionPrice OneQuote { get; set; }

        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }
        [Required]
        public bool Demolition { get; set; }
        [Required]
        [Display(Name = "Demolition metre")]
        [RegularExpression(@"^\d+.\d{0,2}$", ErrorMessage = "Can't have more than 2 decimal places")]
        public float DemMetre { get; set; }
        [Required]
        [Display(Name = "Site Clearance")]
        public bool SiteClear { get; set; }
        [Required]
        [Display(Name = "Site Clearance Amount")]
        [RegularExpression(@"^\d+.\d{0,2}$", ErrorMessage = "Can't have more than 2 decimal places")]
        public float SiteClearMetre { get; set; }
        [Required]
        [HiddenInput(DisplayValue = false)]
        [DisplayFormat(DataFormatString = "{0:n2}", ApplyFormatInEditMode = true)]
        public float PreConTotal { get; set; }

        [Required]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Must have full floors. No decimals")]
        public int Stories { get; set; }
        [Required]
        [Display(Name = "Floor length (metres squared)")]
        [RegularExpression(@"^\d+.\d{0,2}$", ErrorMessage = "Can't have more than 2 decimal places")]
        public float FloorLength { get; set; }
        [Required]
        [HiddenInput(DisplayValue = false)]
        [DisplayFormat(DataFormatString = "{0:n2}")]
        public float StructureCost { get; set; }

        [Required]
        [Display(Name = "External Wall Type")]
        public string ExternalWall { get; set; }
        [Required]
        [Display(Name = "Roof Structure Type")]
        public string RoofStructure { get; set; }
        [Required]
        [HiddenInput(DisplayValue = false)]
        [DisplayFormat(DataFormatString = "{0:n2}")]
        public float SuperStructCost { get; set; }

        [Required]
        [Display(Name = "Roof Tiles Type")]
        public string RoofTiles { get; set; }
        [Required]
        [Display(Name = "Number of doors")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Must have full doors. No decimals")]
        public int NoDoors { get; set; }
        [Required]
        [Display(Name = "Number of windows")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Must have full windows. No decimals")]
        public int NoWindows { get; set; }
        [Required]
        [HiddenInput(DisplayValue = false)]
        [DisplayFormat(DataFormatString = "{0:n2}")]
        public float ExternalCost { get; set; }

        [Required]
        [Display(Name = "Require Plumber?")]
        public bool Plumbing { get; set; }
        [Required]
        [Display(Name = "Require Heating?")]
        public bool Heating { get; set; }
        [Required]
        [Display(Name = "Require Electrician?")]
        public bool Electrics { get; set; }
        [Required]
        [Display(Name = "Require Plasterer?")]
        public bool Plastering { get; set; }
        [Required]
        [Display(Name = "Require Decorator?")]
        public bool Decor { get; set; }
        [Required]
        [Display(Name = "Require Patio doing?")]
        public bool Patio { get; set; }
        [Required]
        [Display(Name = "Patio size (metre squared)")]
        [RegularExpression(@"^\d+.\d{0,2}$", ErrorMessage = "Can't have more than 2 decimal places")]
        public float PatioMetre { get; set; }
        [Required]
        [Display(Name = "Site Drive Way doing?")]
        public bool DriveWay { get; set; }
        [Required]
        [Display(Name = "Drive size (metre squared)")]
        [RegularExpression(@"^\d+.\d{0,2}$", ErrorMessage = "Can't have more than 2 decimal places")]
        public float DriveWayMetre { get; set; }
        [Required]
        [HiddenInput(DisplayValue = false)]
        public float ServicesCost { get; set; }

        [Required]
        [HiddenInput(DisplayValue = false)]
        [DisplayFormat(DataFormatString = "{0:n2}")]
        public float Extra { get; set; }
        [Required]
        [HiddenInput(DisplayValue = false)]
        [DisplayFormat(DataFormatString = "{0:n2}")]
        public float TotalCost { get; set; }
        [HiddenInput(DisplayValue = false)]
        public int UserId { get; set; }
    }
}
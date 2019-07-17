using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FYP.EntityFramework;

namespace FYP.ViewModels
{
    public class RefVM
    {

        public IEnumerable<Reference> list { get; set; }
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }
        [Required]
        [DataType(DataType.MultilineText)]
        public string Reference { get; set; }
        [Required]
        public string Referee { get; set; }
    }
}
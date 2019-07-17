using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FYP.Models
{
    public class References
    {

        public IEnumerable<References> list { get; set; }
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }
        [Required]
        public string Reference { get; set; }
        [Required]
        public string Referee { get; set; }
    }
}
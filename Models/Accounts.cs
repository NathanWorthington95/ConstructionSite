using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;


namespace FYP.Models
{
    public class Accounts
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }
        [Required]
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$",
         ErrorMessage = "The used characters are not allowed.")]
        [MaxLength(15, ErrorMessage = "Please enter a username with less than 15 characters")]
        public string Username { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [System.ComponentModel.DataAnnotations.Compare("Password", ErrorMessage = "Confirm password doesn't match, Type again !")]
        [Display(Name = "Confirm Password")]
        public string ConfirmPass { get; set; }
        [Required]
        [Display(Name = "First Name")]
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$",
         ErrorMessage = "The used characters are not allowed.")]
        public string FirstName { get; set; }
        [Required]
        [Display(Name = "Last Name")]
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$",
         ErrorMessage = "The used characters are not allowed.")]
        public string LastName { get; set; }
        [Required]
        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", ErrorMessage = "Please enter a valid email")]
        public string Email { get; set; }
        [Required]
        [Phone]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid phone number")]
        public string Phone { get; set; }
    }
}
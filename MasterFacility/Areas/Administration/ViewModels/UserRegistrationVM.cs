using MasterFacility.Data.Models.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MasterFacility.Areas.Administration.ViewModels
{
    public class UserRegistrationVM
    {
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Remote(action: "IsEmailExists", controller: "Users", areaName: "Administration", HttpMethod = "Post", AdditionalFields = "Id")]
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        public bool LockoutEnabled { get; set; }
        public ICollection<UserGrantedProvince> GrantedProvinces { get; set; }

        public ICollection<AppRole> AppRoles { get; set; }
    }
}

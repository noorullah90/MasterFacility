using MasterFacility.Data;
using MasterFacility.Data.Models.Identity;
using MasterFacility.Services.Culture;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MasterFacility.Extensions;
using Microsoft.EntityFrameworkCore;

namespace MasterFacility.Services.UserSession
{
    public class UserSession : IUserSession
    {
        private readonly ApplicationDbContext _context;
        private readonly ICulture _culture;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public UserSession(ApplicationDbContext context, ICulture culture, UserManager<AppUser> userManager
            , SignInManager<AppUser> signInManager, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _culture = culture;
            _userManager = userManager;
            _signInManager = signInManager;
            _httpContextAccessor = httpContextAccessor;
        }

        public int Id => Convert.ToInt32(_httpContextAccessor.HttpContext.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value);
        public string UserName => _userManager.GetUserName(_httpContextAccessor.HttpContext.User).ToString();

        //public string FirstName => _httpContextAccessor.HttpContext.User.Identity.GetFirstName();

        public string FirstName => _context.Users.FirstOrDefault(x => x.Id == Id).FirstName;

        public string ImageUrl => _context.Users.FirstOrDefault(x => x.Id == Id).ImageUrl;

        //public string LastName => _httpContextAccessor.HttpContext.User.Identity.GetLastName();
        public string LastName => _context.Users.FirstOrDefault(x => x.Id == Id).LastName;
        public int[] GrantedProvinces => _context.UserGrantedProvinces.Where(x => x.UserId == Id).Select(x => x.Id).ToArray();
       
    }
}

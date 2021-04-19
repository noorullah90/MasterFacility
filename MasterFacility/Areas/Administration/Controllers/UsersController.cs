using MasterFacility.Areas.Administration.ViewModels;
using MasterFacility.Data;
using MasterFacility.Data.Models.Identity;
using MasterFacility.Services.UserSession;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasterFacility.Areas.Administration.Controllers
{
    [Area(MasterFacility.Data.Constants.Areas.Administration)]
    public class UsersController : Controller
    {
        private UserManager<AppUser> _userManger { get; }
        private SignInManager<AppUser> _signInManger { get; }
        private ApplicationDbContext _context;
        private RoleManager<AppRole> _roleManager;
        private IUserSession _session;

        public UsersController(UserManager<AppUser> userManger,
                               SignInManager<AppUser> signInManager,
                               ApplicationDbContext context,
                               IUserSession session)
        {
            _userManger = userManger;
            _signInManger = signInManager;
            _context = context;
            _session = session;
        }

        public IActionResult Index()
        {
            return View();
        }

        //public async Task<IActionResult> Register()
        //{
        //    try
        //    {
        //        ViewBag.Message = "User already registered";

        //        var user = new AppUser();

        //        user.
        //    }
        //    return View();
        //}

        public IActionResult Register()
        {
            return PartialView();
        }

        [HttpPost]
        public async Task<IActionResult> Register(UserRegistrationVM data)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var user = new AppUser
                    {
                        UserName = data.Email,
                        Email = data.Email,
                        FirstName = data.FirstName,
                        LastName = data.LastName,
                        EmailConfirmed = true,
                        PhoneNumberConfirmed = true
                    };
                    var result = await _userManger.CreateAsync(user, data.Password);
                    if (result.Succeeded)
                    {
                        return Json(new
                        {
                            type = "success",
                            title = "successfully",
                            message = "Done!",
                            id = user.Id
                        });
                    }
                }
                catch (Exception e)
                {
                    return Json(new
                    {
                        type = "Error",
                        title = "Some error occured",
                        message = e.ToString()
                    });
                }
            }
            return PartialView(data);
        }

        //public IActionResult Details(int id)
        //{
        //    return PartialView(_context.Users.Include(x=>x.ro).Where(x=>x.Id==id).SingleOrDefault());
        //}

        public IActionResult Edit(int id)
        {
            var user = _context.Users.Where(x => x.Id == id).Select(x => new UserRegistrationVM
            {
                Id = x.Id,
                Email = x.Email,
                FirstName = x.FirstName,
                LastName = x.LastName,
                PhoneNumber = x.PhoneNumber,
                LockoutEnabled = x.LockoutEnabled
            }) ;

            return PartialView(user.SingleOrDefault());
        }

        [HttpPost]
        public async Task<IActionResult> Edit(UserRegistrationVM data)
        {
            try
            {
                var user =  _userManger.Users.FirstOrDefault(x => x.Id == data.Id);


                user.FirstName = data.FirstName;
                user.LastName = data.LastName;
                user.Email = data.Email;
                user.UserName = data.Email;
                user.PhoneNumber = data.PhoneNumber;
                user.LockoutEnabled = data.LockoutEnabled;
                //var user = new AppUser
                //{
                //    Id=data.Id,
                //    UserName = data.Email,
                //    Email = data.Email,
                //    FirstName = data.FirstName,
                //    LastName = data.LastName,
                //    EmailConfirmed = true,
                //    PhoneNumberConfirmed = true
                //};
      
                IdentityResult result = await _userManger.UpdateAsync(user);
                if (result.Succeeded)
                {
                    return Json(new
                    {
                        type = "success",
                        title = "successfully",
                        message = "Done!",
                        id = user.Id
                    });
                }
                else
                {
                    return Json(new
                    {
                        type = "error",
                        title = "successfully",
                        message = "Done!"
                    });
                }
            }
            catch (Exception e)
            {
                return Json(new
                {
                    type = "error",
                    title = "Some error occured",
                    message = e.ToString()
                });
            }
        }


        public IActionResult Details(int Id)
        {
            return PartialView(_context.Users.Where(x => x.Id == Id).Include(x => x.GrantedProvinces).ThenInclude(it => it.Province).FirstOrDefault());
        }
        public IActionResult UserList(int pageIdex, int pageSize)
        {
            return Json(_context.Users.Skip(pageIdex * pageSize).Take(pageSize));
        }

        public IActionResult IsEmailExists(string Email, int Id)
        {
            if (!_context.Users.Any(x => x.Email.Equals(Email) && x.Id != Id))
            {
                return Json(true);
            }
            else
            {
                return Json(false);
            }
        }

        //public IActionResult AddProvince(int id)
        //{
        //    return PartialView(new UserGrantedProvince
        //    {
        //        UserId=id
        //    });
        //}

        //[HttpPost]
        //public async Task<IActionResult> AddProvince(UserGrantedProvince data)
        //{
        //    try
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            data.Id = 0;

        //            if (_context.UserGrantedProvinces.Any(x => x.ProvinceId.Equals(data.ProvinceId) && x.UserId.Equals(data.UserId)))
        //            {
        //                return MessageBox.Show(MessageType.Error);
        //            }

        //            _context.UserGrantedProvinces.Add(data);
        //            await _context.SaveChangesAsync(_session.Id);
        //            return MessageBox.Show(MessageType.Success);
        //        }
        //        else
        //        {
        //            return MessageBox.Show(MessageType.NotValid);
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        return MessageBox.Show(MessageType.Error);
        //    }
        //}


        public async Task<IActionResult> AddProvinces(int id)
        {
            var ids = await _context.UserGrantedProvinces.Where(x => x.UserId == id).Select(x => x.ProvinceId).ToArrayAsync();
            return PartialView(_context.provinces.Where(x => x.isactive == true && !ids.Contains(x.id)).ToList());
        }
        [HttpPost]
        public async Task<IActionResult> AddProvinces(UserGrantedProvince[] data)
        {
            try
            {
                _context.UserGrantedProvinces.AddRange(data);
                await _context.SaveChangesAsync(_session.Id);
                return MessageBox.Show(MessageType.Success);
            }
            catch(Exception e)
            {
                return MessageBox.Show(MessageType.Error);
            }
        }

        [HttpPost]
        public async Task<IActionResult> DeleteProvince(int id)
        {
            try
            {
                var record = _context.UserGrantedProvinces.Find(id);
                _context.UserGrantedProvinces.Remove(record);
                await _context.SaveChangesAsync(_session.Id);
                return MessageBox.Show(MessageType.Success);
            }
            catch(Exception e)
            {
                return MessageBox.Show(MessageType.Error);
            }
        }

    }
}

using MasterFacility.Data;
using MasterFacility.Data.Models.Lookups;
using MasterFacility.Services.Culture;
using MasterFacility.Services.UserSession;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasterFacility.Areas.Administration.Controllers
{
    [Area(MasterFacility.Data.Constants.Areas.Administration)]
    public class DistrictController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IUserSession _session;
        private readonly ICulture _culture;

        public DistrictController(ApplicationDbContext context,
                                  IUserSession session,
                                  ICulture culture)
        {
            _context = context;
            _session = session;
            _culture = culture;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult getList(bool onlyActive=true)
        {
            try
            {
                var draw = HttpContext.Request.Form["draw"].FirstOrDefault();
                // Skiping number of Rows count  
                var start = Request.Form["start"].FirstOrDefault();
                // Paging Length 10,20  
                var length = Request.Form["length"].FirstOrDefault();
                // Sort Column Name  
                var sortColumn = Request.Form["columns[" + Request.Form["order[0][column]"].FirstOrDefault() + "][name]"].FirstOrDefault();
                // Sort Column Direction ( asc ,desc)  
                var sortColumnDirection = Request.Form["order[0][dir]"].FirstOrDefault();
                // Search Value from (Search box)  
                var searchValue = Request.Form["search[value]"].FirstOrDefault();

                //Paging Size (10,20,50,100)  
                int pageSize = length != null ? Convert.ToInt32(length) : 0;
                int skip = start != null ? Convert.ToInt32(start) : 0;
                int recordsTotal = 0;
                // Getting all Customer data  

                var districts = _context.districts.Where(x=>x.isactive==onlyActive).Include(x => x.province).Skip(skip).Take(pageSize).Select(x => new
                {
                    id = x.id,
                    province = x.province.name,
                    name = x.name,
                    namedari = x.namedari,
                    namepashto = x.namepashto,
                    isactive = x.isactive

                }).ToList();

                //Sorting  
                //if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDirection)))
                //{
                //    employeeData = employeeData.OrderBy(sortColumn + " " + sortColumnDirection);
                //}
                //Search  
                //if (!string.IsNullOrEmpty(searchValue))
                //{
                //    districts.Where(x => EF.Functions.Like(x.name, "%" + searchValue + "%") || EF.Functions.Like(x.namedari, "%" + searchValue + "%")).Skip(skip).Take(pageSize).ToList();
                //}
                //else
                //{
                //    districts.Skip(skip).Take(pageSize);
                //}

                //total number of rows count   
                recordsTotal = _context.districts.Where(x => x.isactive == onlyActive).Count();
                //Returning Json Data  
                return Json(new { draw = draw, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = districts });

            }
            catch (Exception e)
            {
                return Json(e);
            }

        }


        public IActionResult geListByProvince(int provinceId)
        {
            try
            {
                var draw = HttpContext.Request.Form["draw"].FirstOrDefault();
                // Skiping number of Rows count  
                var start = Request.Form["start"].FirstOrDefault();
                // Paging Length 10,20  
                var length = Request.Form["length"].FirstOrDefault();
                // Sort Column Name  
                var sortColumn = Request.Form["columns[" + Request.Form["order[0][column]"].FirstOrDefault() + "][name]"].FirstOrDefault();
                // Sort Column Direction ( asc ,desc)  
                var sortColumnDirection = Request.Form["order[0][dir]"].FirstOrDefault();
                // Search Value from (Search box)  
                var searchValue = Request.Form["search[value]"].FirstOrDefault();

                //Paging Size (10,20,50,100)  
                int pageSize = length != null ? Convert.ToInt32(length) : 0;
                int skip = start != null ? Convert.ToInt32(start) : 0;
                int recordsTotal = 0;
                // Getting all Customer data  

                var districts = _context.districts.Where(x=>x.provinceid==provinceId).Include(x => x.province).Skip(skip).Take(pageSize).Select(x => new
                {
                    id = x.id,
                    province = x.province.name,
                    name = x.name,
                    namedari = x.namedari,
                    namepashto = x.namepashto,
                    isactive = x.isactive

                }).ToList();

                //Sorting  
                //if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDirection)))
                //{
                //    employeeData = employeeData.OrderBy(sortColumn + " " + sortColumnDirection);
                //}
                //Search  
                //if (!string.IsNullOrEmpty(searchValue))
                //{
                //    districts.Where(x => EF.Functions.Like(x.name, "%" + searchValue + "%") || EF.Functions.Like(x.namedari, "%" + searchValue + "%")).Skip(skip).Take(pageSize).ToList();
                //}
                //else
                //{
                //    districts.Skip(skip).Take(pageSize);
                //}

                //total number of rows count   
                recordsTotal = _context.districts.Where(x=>x.provinceid==provinceId).Count();
                //Returning Json Data  
                return Json(new { draw = draw, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = districts });

            }
            catch (Exception e)
            {
                return Json(e);
            }

        }
        public IActionResult Create()
        {
            return PartialView();
        }
       
        public IActionResult Edit(int id)
        {
            return PartialView(_context.districts.Find(id));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(district data)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.districts.Update(data);
                    await _context.SaveChangesAsync(_session.Id);
                    return MessageBox.Show(MessageType.Success);

                }
                else
                {
                    return MessageBox.Show(MessageType.NotValid);
                }
            }
            catch (Exception e)
            {
                return MessageBox.Show(MessageType.Error);
            }
        }
    }
}

using MasterFacility.Data;
using MasterFacility.Data.Models.Lookups;
using MasterFacility.Services.Culture;
using MasterFacility.Services.UserSession;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasterFacility.Areas.Administration.Controllers
{
    [Area(Data.Constants.Areas.Administration)]
    public class ProvinceController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IUserSession _session;
        private readonly ICulture _culture;

        public ProvinceController(ApplicationDbContext context,
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

        public IActionResult ProvinceList()
        {
            return PartialView("_ProvinceList", _context.provinces.ToList());
        }

        public IActionResult Provinces()
        {
            return Json(_context.provinces.ToList());
        }
        public IActionResult Create()
        {
            return PartialView();
        }

        [HttpPost]
        public async Task<IActionResult> Create(province data)
        {
            try
            {
                _context.provinces.Add(data);
                data.isactive = true;
                await _context.SaveChangesAsync(_session.Id);
                return MessageBox.Show(MessageType.Success);
            }
            catch(Exception e)
            {
                return MessageBox.Show(MessageType.Error);
            }
        }

        public IActionResult Edit(int id)
        {
            var province = _context.provinces.Find(id);
            return PartialView(province);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(province data)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.provinces.Update(data);
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

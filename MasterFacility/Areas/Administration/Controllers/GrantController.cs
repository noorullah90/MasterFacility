using MasterFacility.Data;
using MasterFacility.Data.Models.Grants;
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
    public class GrantController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IUserSession _session;
        private readonly ICulture _culture;

        public GrantController(ApplicationDbContext context,
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

        public IActionResult GrantList()
        {
        
            return PartialView("_GrantList", _context.grants.ToList());
        }

        public IActionResult grants()
        {
            return Json(_context.grants.ToList());
        }
        public IActionResult Create()
        {
            return PartialView();
        }

        [HttpPost]
        public async Task<IActionResult> Create(grant data)
        {
            try
            {
                _context.grants.Add(data);
                data.isactive = true;
                await _context.SaveChangesAsync(_session.Id);
                return MessageBox.Show(MessageType.Success);
            }
            catch (Exception e)
            {
                return MessageBox.Show(MessageType.Error);
            }
        }
        
        public IActionResult Edit(string id)
        {
            return PartialView(_context.grants.Find(id));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(grant data)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.grants.Update(data);
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

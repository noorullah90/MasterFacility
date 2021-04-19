﻿using MasterFacility.Data;
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
    public class DonorController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IUserSession _session;
        private readonly ICulture _culture;

        public DonorController(ApplicationDbContext context,
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

        public IActionResult DonorList()
        {
        
            return PartialView("_DonorList", _context.donors.ToList());
        }

        public IActionResult donors()
        {
            return Json(_context.donors.ToList());
        }
        public IActionResult Create()
        {
            return PartialView();
        }

        [HttpPost]
        public async Task<IActionResult> Create(donor data)
        {
            try
            {
                _context.donors.Add(data);
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
            return PartialView(_context.donors.Find(id));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(donor data)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.donors.Update(data);
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

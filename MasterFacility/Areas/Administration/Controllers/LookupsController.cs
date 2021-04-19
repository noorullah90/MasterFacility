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
    [Area(Data.Constants.Areas.Administration)]
    public class LookupsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ICulture _culture;
        private readonly IUserSession _session;

        public LookupsController(ApplicationDbContext context,
                                 ICulture culture,
                                 IUserSession session)
        {
            _context = context;
            _culture = culture;
            _session = session;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ListLookups()
        {
            return PartialView(_context.lookups.ToList());
        }
       public IActionResult Create()
        {
            return PartialView();
        }

        [HttpPost]
        public async Task<IActionResult> Create(lookup data)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    _context.lookups.Add(data);
                    await _context.SaveChangesAsync(_session.Id);
                    return Json(new
                    {
                        type = "success",
                        title = "successfully",
                        message = "Done!"
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
            catch(Exception e)
            {
                return Json(new
                {
                    type = "error",
                    title = "successfully",
                    message = "Done!"
                });
            }
        }

        public IActionResult Edit(int id)
        {
            return PartialView(_context.lookups.Find(id));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(lookup data)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.lookups.Update(data);
                    await _context.SaveChangesAsync(_session.Id);
                    return Json(new
                    {
                        type = "success",
                        title = "successfully",
                        message = "Done!"
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
                    title = "successfully",
                    message = "Done!"
                });
            }
        }

        public IActionResult Items()
        {
            return View();
        }

        public IActionResult ListofItems()
        {
            return PartialView(_context.lookupitems.Include(x => x.lookup).ToList());
        }
        public IActionResult CreateItem()
        {

            return PartialView();
                
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateItem(lookupitem data)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.lookupitems.Add(data);
                    await _context.SaveChangesAsync(_session.Id);
                    return Json(new
                    {
                        type = "success",
                        title = "successfully",
                        message = "Done!"
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
                    title = "successfully",
                    message = "Done!"
                });
            }
        }

        public IActionResult ItemDetail(int id)
        {
            return PartialView(_context.lookupitems.Where(x => x.id == id).Include(x => x.lookup).Include(x=> x.parent).Include(x=>x.lookupitems).SingleOrDefault());
        }

        public IActionResult EditItem(int id)
        {
            return PartialView(_context.lookupitems.Find(id));
        }
        public JsonResult IsHmisExists(string hmisid, int lookupid, int? id)
        {
            var result = _context.lookupitems.Where(x => x.hmisid.Equals(hmisid) && x.lookupid==lookupid && x.id != id).FirstOrDefault();
            if(result==null)
            {
                return Json(true);
            }
            else
            {
                return Json(false);
            }
        }
    }
}

using MasterFacility.Data;
using MasterFacility.Services.Culture;
using MasterFacility.Services.UserSession;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasterFacility.Controllers
{
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

        public IActionResult ListProvinces()
        {
            return Json(_context.provinces.Select(x => new
            {
                id = x.id,
                name = _culture.GetLanguageId() == 1 ? x.name : x.namedari
            }).ToList());
        }

        public IActionResult ListLookupCategories()
        {
            return Json(_context.lookups.Select(x => new
            {
                id = x.id,
                name = _culture.GetLanguageId() == 1 ? x.name : x.namedari
            }).ToList());
        }

        public IActionResult ListLookups(int lookupid, int? parentid)
        {
            var list = _context.lookupitems.Where(x => x.lookupid == lookupid);
            if (parentid != null)
                list.Where(x => x.parentid == parentid);

            return Json(list.Select(x => new
            {
                id = x.id,
                name = _culture.GetLanguageId() == 1 ? x.name : x.namedari
            }).ToList());
        }

        public IActionResult dataList()
        {
            var data = _context.implementers.Include(x => x.grants).ThenInclude(e=>e.program).ThenInclude(d=>d.donor).Take(2).ToList() ;
            return Json(JsonConvert.SerializeObject(data, Formatting.None, new JsonSerializerSettings() { 
            ReferenceLoopHandling=ReferenceLoopHandling.Ignore
            }));
        }
    }
}

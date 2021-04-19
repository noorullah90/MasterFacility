using MasterFacility.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasterFacility.Services.Culture
{
    public class Culture : ICulture
    {
        private readonly ApplicationDbContext _context;

        public Culture(ApplicationDbContext context)
        {
            _context = context;
        }
        public int GetLanguageId()
        {
            var culture = System.Threading.Thread.CurrentThread.CurrentCulture.Name.Split('-')[0].ToLower();
            var LanguageId = _context.languages.SingleOrDefault(e => e.code == culture).id;
            return LanguageId;
        }
    }
}

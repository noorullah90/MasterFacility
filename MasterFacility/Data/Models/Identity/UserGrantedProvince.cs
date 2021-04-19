using MasterFacility.Data.Models.Lookups;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasterFacility.Data.Models.Identity
{
    public class UserGrantedProvince
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public AppUser User { get; set; }
        public int ProvinceId { get; set; }
        public province Province { get; set; }
    }
}

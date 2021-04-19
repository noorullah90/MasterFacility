using MasterFacility.Data.Models.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasterFacility.Services.UserSession
{
    public interface IUserSession
    {
        public int Id { get; }
        public string UserName { get; }
        public string FirstName { get; }
        public string LastName { get; }
        public string ImageUrl { get; }

        public int[] GrantedProvinces { get; }
    }
}

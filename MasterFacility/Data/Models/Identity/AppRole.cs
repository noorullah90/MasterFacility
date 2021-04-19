using Microsoft.AspNetCore.Identity;

namespace MasterFacility.Data.Models.Identity
{
    public class AppRole : IdentityRole<int>
    {
        public string Descriptions { get; set; }
    }
}
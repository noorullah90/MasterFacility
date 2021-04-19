using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;

namespace MasterFacility.Extensions
{
    public static class IdentityExtension
    {
        public static string GetFirstName(this IIdentity identity)
        {
            if (identity == null)
                return null;

            var FirstName = (identity as ClaimsIdentity).FirstOrNull("FirstName");

            return FirstName;
        }

        public static string GetLastName(this IIdentity identity)
        {
            if (identity == null)
                return null;

            var LastName = (identity as ClaimsIdentity).FirstOrNull("LastName");

            return LastName;
        }

        internal static string FirstOrNull(this ClaimsIdentity identity, string claimType)
        {
            var val = identity.FindFirst(claimType);

            return val == null ? null : val.Value;
        }
    }
}

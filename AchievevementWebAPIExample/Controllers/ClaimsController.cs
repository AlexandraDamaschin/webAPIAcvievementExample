using AchievevementWebAPIExample.Models;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Threading;
using System.Web.Http;

namespace AchievevementWebAPIExample.Controllers
{
    [Authorize]
    public class ClaimsController : ApiController
    {
        ApplicationUserManager _userManager;

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? Request.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        public dynamic getClaims()
        {
            var identity = (ClaimsIdentity)User.Identity;
            IEnumerable<Claim> claims = identity.Claims;

            var userClaim = claims
                            .Where(c => c.Type == ClaimTypes.Name);
            return userClaim;
        }
    }
}

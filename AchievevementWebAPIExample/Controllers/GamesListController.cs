using AchievevementWebAPIExample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AchievevementWebAPIExample.Controllers
{
    [RoutePrefix("api/games")]
    public class GamesListController : ApiController
    {
        ApplicationDbContext db = new ApplicationDbContext();
        [Route("ListGames")]
        public dynamic getGameList()
        {
            return db.Games.ToList();
        }

        [Authorize]
        [Route("GamerInfo")]
        public dynamic getGamerInfo()
        {
            var info =  db.Users.Where(u => u.UserName == User.Identity.Name)
                    .Select(p => new { p.GamerTag, p.XP });
            return info;
            
        }

    }
}

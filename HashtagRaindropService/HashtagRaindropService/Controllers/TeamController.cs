using HashtagRaindropService.Models;
using HashtagRaindropService.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace HashtagRaindropService.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class TeamController : ApiController
    {
        [Route("teams/")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetAll()
        {
            var players = PlayerRepository.GetAll();
            var teams = TeamRepository.GetAll();

            foreach (var team in teams)
            {
                team.Score = 0;
                team.Makes = 0;
                team.Misses = 0;
                team.Attempts = 0;
            }

            foreach (var player in players)
            {
                player.Attempts = player.Misses + player.Makes;
                player.Team.Score += player.Score;
                player.Team.Makes += player.Makes;
                player.Team.Misses += player.Misses;
                player.Team.Attempts += player.Attempts;
            }

            return Ok(teams);
        }
    }
}

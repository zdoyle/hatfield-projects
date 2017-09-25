using HashtagRaindropService.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HashtagRaindropService.Models.Repositories
{
    public class TeamRepository
    {
        private static List<Team> _teams = new List<Team>()
        {
            new Team
            {
                TeamId=1,
                TeamName="Back End",
                AvatarURL="http://www.caskeys.com/dc/wp-content/uploads/2016/06/logo-php.png",
                TeamColor="rgb(80,94,155,0.4)",
            },
            new Team
            {
                TeamId=2,
                TeamName="Front End",
                AvatarURL="https://pbs.twimg.com/profile_images/993504415/css_400x400.png",
                TeamColor="rgba(103,1,103, 0.4)",
            }
        };


        public static List<Team> GetAll()
        {
            return _teams;
        }

        public static Team Get(int teamId)
        {
            return _teams.FirstOrDefault(p => p.TeamId == teamId);
        }

        public static void Create(Team newTeam)
        {
            if (_teams.Any())
            {
                newTeam.TeamId = _teams.Max(p => p.TeamId) + 1;
            }
            else
            {
                newTeam.TeamId = 1;
            }

            _teams.Add(newTeam);
        }

        public static void Update(Team updatedTeam)
        {
            _teams.RemoveAll(p => p.TeamId == updatedTeam.TeamId);
            _teams.Add(updatedTeam);
        }

        public static void Delete(int teamId)
        {
            _teams.RemoveAll(p => p.TeamId == teamId);
        }

        private static void resetTeamScores()
        {
            var players = PlayerRepository.GetAll();

            foreach (var team in _teams)
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
        }

    }
}
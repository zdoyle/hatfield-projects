using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HashtagRaindropService.Models
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
                TeamColor="#526191",
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
    }
}
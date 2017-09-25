using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HashtagRaindropService.Models
{
    public class PlayerRepository
    {
        private static List<Player> _players = new List<Player>()
        {
            new Player
            {
                PlayerId=1,
                FirstName ="Steve",
                LastName="Clark",
                Team=TeamRepository.Get(1),
                AvatarURL="https://www.godaddy.com/garage/wp-content/uploads/2014/06/create-a-gravatar-beard.png",
                Score=10,
                Makes=10,
                Misses=7
            }
        };

        public static List<Player> GetAll()
        {
            resetTeamScores();

            return _players;
        }


        public static Player Get(int playerId)
        {
            resetTeamScores();

            return _players.FirstOrDefault(p => p.PlayerId == playerId);
        }

        public static void Create (Player newPlayer)
        {
            if (_players.Any())
            {
                newPlayer.PlayerId = _players.Max(p => p.PlayerId) + 1;
            }
            else
            {
                newPlayer.PlayerId = 1;
            }

            _players.Add(newPlayer);
        }

        public static void Update(Player updatedPlayer)
        {
            _players.RemoveAll(p => p.PlayerId == updatedPlayer.PlayerId);
            _players.Add(updatedPlayer);
        }

        public static void Delete(int playerId)
        {
            _players.RemoveAll(p => p.PlayerId == playerId);
        }

        private static void resetTeamScores()
        {
            var teams = TeamRepository.GetAll();

            foreach (var team in teams)
            {
                team.Score = 0;
                team.Makes = 0;
                team.Misses = 0;
                team.Attempts = 0;
            }

            foreach (var player in _players)
            {
                player.Team.Score += player.Score;
                player.Team.Makes += player.Makes;
                player.Team.Misses += player.Misses;
                player.Team.Attempts += player.Attempts;
            }
        }
    }
}
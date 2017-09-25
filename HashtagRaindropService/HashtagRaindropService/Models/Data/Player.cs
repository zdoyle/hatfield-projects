using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HashtagRaindropService.Models.Data
{
    public class Player
    {
        public int PlayerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Team Team { get; set; }
        public string AvatarURL { get; set; }
        public string TwitterUsername { get; set; }
        public int Score { get; set; }
        public int Makes { get; set; }
        public int Misses { get; set; }
        public int Attempts { get; set; }
    }
}
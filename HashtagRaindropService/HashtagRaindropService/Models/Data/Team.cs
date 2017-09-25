using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HashtagRaindropService.Models.Data
{
    public class Team
    {
        public int TeamId { get; set; }
        public string TeamName { get; set; }
        public string AvatarURL { get; set; }
        public string TeamColor { get; set; }
        public int Score { get; set; }
        public int Makes { get; set; }
        public int Misses { get; set; }
        public int Attempts { get; set; }
    }
}
﻿using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Games.DAL.Entities
{
    public partial class Games
    {
        public Games()
        {
            GamesCategory = new HashSet<GamesCategory>();
            GamesPlatforms = new HashSet<GamesPlatforms>();
        }

        public int IdGame { get; set; }
        public string FkUsername { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? LaunchDate { get; set; }
        public decimal Height { get; set; }
        public bool Multiplayer { get; set; }

        public virtual Users FkUsernameNavigation { get; set; }
        public virtual ICollection<GamesCategory> GamesCategory { get; set; }
        public virtual ICollection<GamesPlatforms> GamesPlatforms { get; set; }
    }
}
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Entities
{
    public class Movie
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateTime? PublishDate{ get; set; }
        public string? Poster { get; set; }
        public int? Duration{ get; set; }
        public double? Rating{ get; set; }

        //Navigation Property
        public Director? Director { get; set; }
        public int? DirectorId { get; set; }

        public ICollection<MoviesPlayer> Players { get; set; } = new HashSet<MoviesPlayer>();

    }
}

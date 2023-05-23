using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Entities
{
    public class Player
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? Info{ get; set; }

        public ICollection<MoviesPlayer> Movies { get; set; } = new HashSet<MoviesPlayer>();
    }
}

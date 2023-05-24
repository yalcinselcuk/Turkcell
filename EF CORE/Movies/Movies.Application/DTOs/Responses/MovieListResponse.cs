using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Application.DTOs.Responses
{
    public class MovieListResponse
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateTime? PublishDate { get; set; }
        public string? Poster { get; set; }
        public int? Duration { get; set; }
        public double? Rating { get; set; }
        public string? DirectoryName { get; set; }//özel bir şey ekledik
        public string? Players { get; set; }


    }
}

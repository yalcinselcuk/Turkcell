using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Application.DTOs.Requests
{
    public class UpdateMovieRequest
    {
        //kullanıcının gördüğü ekrandan alacağımız için bu değişkenleri tuttuk
        //id ile güncelleyeceğimizden onu da aldık
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateTime? PublishDate { get; set; }
        public string? Poster { get; set; }
        public int? Duration { get; set; }
        public double? Rating { get; set; }
        public int? DirectorId { get; set; }
    }
}

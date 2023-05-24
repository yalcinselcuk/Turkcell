using Movies.Application.DTOs.Requests;
using Movies.Application.DTOs.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Application
{
    public interface IMovieService
    {
        Task<int> CreateNewMovie(CreateNewMovieRequest createNewMovie);
        Task UpdateMovie(UpdateMovieRequest updateMovie);

        Task<IEnumerable<MovieListResponse>> GetAllMovies();
        //sadece foreach ile listeyi dönmek istiyoruz
    }
}

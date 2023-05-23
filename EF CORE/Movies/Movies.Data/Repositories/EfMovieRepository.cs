using Movies.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Data.Repositories
{
    public class EfMovieRepository : IMovieRepository
    {
        public Task CreateAsync(Movie entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<Movie>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Movie> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<Movie>> SearchMoviesByTitle(string title)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Movie entity)
        {
            throw new NotImplementedException();
        }
    }
}

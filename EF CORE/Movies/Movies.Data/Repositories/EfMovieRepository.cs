using Movies.Data.Data;
using Movies.Entities;
using Microsoft.EntityFrameworkCore;

namespace Movies.Data.Repositories
{
    public class EfMovieRepository : IMovieRepository
    {
        private readonly MoviesDbContext moviesDbContext;

        public EfMovieRepository(MoviesDbContext moviesDbContext)
        {
            this.moviesDbContext = moviesDbContext;
        }
        public async Task CreateAsync(Movie entity)
        {
            await moviesDbContext.Movies.AddAsync(entity);
            await moviesDbContext.SaveChangesAsync();//Persistence API
        }

        public async Task DeleteAsync(int id)
        {
            var movie = await moviesDbContext.Movies.AsNoTracking().FirstOrDefaultAsync(movie => movie.Id == id);
            moviesDbContext.Movies.Remove(movie);
            await moviesDbContext.SaveChangesAsync();
        }

        public async Task<ICollection<Movie>> GetAllAsync()
        {
            var movie = await moviesDbContext.Movies.AsNoTracking().ToListAsync();
            return movie;
        }

        public async Task<Movie?> GetByIdAsync(int id)
        {
            //FirstOrDefault null döndürebilir, sorun olmasın diye Movie'nin boş olabileceğini belirttik
            var movie = await moviesDbContext.Movies.AsNoTracking().FirstOrDefaultAsync(movie => movie.Id == id);
            return movie;
        }

        public async Task<ICollection<Movie>> SearchMoviesByTitle(string title)
        {
            return await moviesDbContext.Movies.AsNoTracking()
                                                    .Where(movie => movie.Name.Contains(title))
                                                    .ToListAsync();
        }

        public async Task UpdateAsync(Movie entity)
        {
            moviesDbContext.Movies.Update(entity);
            await moviesDbContext.SaveChangesAsync();
        }
    }
}

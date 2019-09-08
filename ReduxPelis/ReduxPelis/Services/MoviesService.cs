using ReduxPelis.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ReduxPelis.Services
{
    public class MoviesService : IMoviesService
    {
        private Movie[] _movies = new[]
        {
            new Movie{
                Id = Guid.NewGuid(),
                Title = "It: Chapter Two",
                Poster="https://image.tmdb.org/t/p/w185_and_h278_bestv2/jCgt7buyQgnIJ8EnFBTBuNvehUO.jpg"
             },
            new Movie{
                Id = Guid.NewGuid(),
                Title = "Fast & Furious Presents: Hobbs & Shaw",
                Poster="https://image.tmdb.org/t/p/w185_and_h278_bestv2/keym7MPn1icW1wWfzMnW3HeuzWU.jpg"
             },
            new Movie{
                Id = Guid.NewGuid(),
                Title = "Angel Has Fallen",
                Poster="https://image.tmdb.org/t/p/w185_and_h278_bestv2/fapXd3v9qTcNBTm39ZC4KUVQDNf.jpg"
             },
            new Movie{
                Id = Guid.NewGuid(),
                Title = "Good Boys",
                Poster="https://image.tmdb.org/t/p/w185_and_h278_bestv2/jIthqo2tQmW8TFN1fYpF8FmVL0o.jpg"
             }
        };
        public async Task<Movie[]> GetAvailableMovies()
        {
            await Task.Delay(1500);
            return _movies;
        }

        public async Task<Movie> GetMovie(Guid id)
        {
            await Task.Delay(500);
            return _movies.FirstOrDefault(i=>i.Id == id);
        }
    }
}

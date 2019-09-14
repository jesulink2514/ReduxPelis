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
                Poster="https://image.tmdb.org/t/p/w185_and_h278_bestv2/jCgt7buyQgnIJ8EnFBTBuNvehUO.jpg",
                Plot = "Defeated by members of the Losers' Club, the evil clown Pennywise returns 27 years later to terrorize the town of Derry, Maine, once again. Now adults, the childhood friends have long since gone their separate ways. But when people start disappearing, Mike Hanlon calls the others home for one final stand. Damaged by scars from the past, the united Losers must conquer their deepest fears to destroy the shape-shifting Pennywise -- now more powerful than ever."
            },
            new Movie{
                Id = Guid.NewGuid(),
                Title = "Fast & Furious Presents: Hobbs & Shaw",
                Poster="https://image.tmdb.org/t/p/w185_and_h278_bestv2/keym7MPn1icW1wWfzMnW3HeuzWU.jpg",
                Plot = "Brixton Lorr is a cybernetically enhanced soldier who possesses superhuman strength, a brilliant mind and a lethal pathogen that could wipe out half of the world's population. It's now up to hulking lawman Luke Hobbs and lawless operative Deckard Shaw to put aside their past differences and work together to prevent the seemingly indestructible Lorr from destroying humanity."
             },
            new Movie{
                Id = Guid.NewGuid(),
                Title = "Angel Has Fallen",
                Poster="https://image.tmdb.org/t/p/w185_and_h278_bestv2/fapXd3v9qTcNBTm39ZC4KUVQDNf.jpg",
                Plot = "Authorities take Secret Service agent Mike Banning into custody for the failed assassination attempt of U.S. President Allan Trumbull. After escaping from his captors, Banning must evade the FBI and his own agency to find the real threat to the president. Desperate to uncover the truth, he soon turns to unlikely allies to help clear his name and save the country from imminent danger."
             },
            new Movie{
                Id = Guid.NewGuid(),
                Title = "Good Boys",
                Poster="https://image.tmdb.org/t/p/w185_and_h278_bestv2/jIthqo2tQmW8TFN1fYpF8FmVL0o.jpg",
                Plot = "Invited to his first kissing party, 12-year-old Max asks his best friends Lucas and Thor for some much-needed help on how to pucker up. When they hit a dead end, Max decides to use his father's drone to spy on the teenage girls next door. When the boys lose the drone, they skip school and hatch a plan to retrieve it before Max's dad can figure out what happened."
             }
        };

        public MoviesService()
        {
            var times = new[]
            {
                DateTime.Now.Date.Add(new TimeSpan(17,0,0)),
                DateTime.Now.Date.Add(new TimeSpan(19,0,0)),
                DateTime.Now.Date.Add(new TimeSpan(21,0,0)),
            };

            foreach (var movie in _movies)
            {
                movie.Functions = times;
            }
        }
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

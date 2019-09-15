using System;
using System.Threading.Tasks;
using ReduxPelis.Models;

namespace ReduxPelis.Services
{
    public interface IMoviesService
    {
        Task<Movie> GetMovie(Guid id);
        Task<Movie[]> GetAvailableMovies();

        Task<Ticket> BuyTicketFor(Guid movieId, DateTime function);
        Task<Ticket[]> GetTickets();
    }
}
using GraphQLProject.Models;

namespace GraphQLProject.Interfaces;

public interface IReservationRepository
{
    Task<List<Reservation>> GetReservations();
    Task<Reservation> AddReservaReservation(Reservation reservation);
}

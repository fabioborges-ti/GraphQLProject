using GraphQLProject.Models;

namespace GraphQLProject.Interfaces;

public interface IReservationRepository
{
    Task<List<ReservationModel>> GetReservations();
    Task<ReservationModel> AddReservaReservation(ReservationModel reservation);
}

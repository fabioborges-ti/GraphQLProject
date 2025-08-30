using GraphQLProject.Interfaces;
using GraphQLProject.Models;
using Microsoft.EntityFrameworkCore;

namespace GraphQLProject.Repositories;

public class ReservationRepository : IReservationRepository
{
    private readonly GraphQLDbContext _dbContext;

    public ReservationRepository(GraphQLDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Reservation> AddReservaReservation(Reservation reservation)
    {
        _dbContext.Reservations.Add(reservation);

        await _dbContext.SaveChangesAsync();

        return reservation;
    }

    public async Task<List<Reservation>> GetReservations()
    {
        return await _dbContext.Reservations.ToListAsync();
    }
}

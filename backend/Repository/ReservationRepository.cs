using Hotel_Management.Data;
using Hotel_Management.Model.Entity;
using Hotel_Management.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Hotel_Management.Repository
{
    public class ReservationRepository : IReservationRepository
    {
        private readonly HotelManagementContext _context;
        public ReservationRepository(HotelManagementContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Reservation>> Get()
        {
            return await _context.Reservations
                                        .Include(x => x.Client)
                                        .Include(x => x.Room)
                                        .ThenInclude(x => x.Hotel)
                                        .ToListAsync();
        }

        public async Task<Reservation> GetById(int id)
        {
            return await _context.Reservations
                                        .Include(x => x.Client)
                                        .Include(x => x.Room)
                                        .ThenInclude(x => x.Hotel)
                                        .Where(r => r.Id == id)
                                        .FirstOrDefaultAsync();
        }
        public async Task<Reservation> GetByRoomId(int id)
        {
            return await _context.Reservations
                                        .Where(r => r.Room_id == id)
                                        .FirstOrDefaultAsync();
        }

        public void Create(Reservation reservation)
        {
            _context.Add(reservation);
        }
        public void Cancel(Reservation reservation)
        {
           _context.Update(reservation);
        }
        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

    }
}

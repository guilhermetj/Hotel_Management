using Hotel_Management.Data;
using Hotel_Management.Model.Entity;
using Hotel_Management.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Hotel_Management.Repository
{
    public class RoomRepository : IRoomRepository
    {
        private readonly HotelManagementContext _context;
        public RoomRepository(HotelManagementContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Room>> Get()
        {
            return await _context.Rooms
                                 .Include(x => x.Hotel)
                                 .ToListAsync();
        }
        public async Task<Room> GetById(int id)
        {
            return await _context.Rooms
                                 .Include(x => x.Hotel)
                                 .Where(x => x.Id == id)
                                 .FirstOrDefaultAsync();
        }
        public void Create(Room room)
        {
            _context.Add(room);
        }
        public void Update(Room room)
        {
            _context.Update(room);
        }
        public void Delete(Room room)
        {
            _context.Remove(room);
        }
        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}

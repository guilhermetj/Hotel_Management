using Hotel_Management.Data;
using Hotel_Management.Model.Entity;
using Hotel_Management.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Hotel_Management.Repository
{
    public class HotelRepository : IHotelRepository
    {
        private readonly HotelManagementContext _context;
        public HotelRepository(HotelManagementContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Hotel>> Get()
        {
            return await _context.Hotels
                                    .ToListAsync();
        }

        public async Task<Hotel> GetById(int id)
        {
            return await _context.Hotels
                                    .Where(x => x.Id == id)
                                    .FirstOrDefaultAsync(); 
        }

        public void Create(Hotel hotel)
        {
            _context.Add(hotel);
        }

        public void Update(Hotel hotel)
        {
            _context.Update(hotel);
        }
        public void Disable(Hotel hotel)
        {
            _context.Update(hotel);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}

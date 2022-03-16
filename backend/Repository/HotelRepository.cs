using Hotel_Management.Data;
using Hotel_Management.Model.Entity;
using Hotel_Management.Repository.Interfaces;

namespace Hotel_Management.Repository
{
    public class HotelRepository : IHotelRepository
    {
        private readonly HotelManagemnetContext _context;
        public HotelRepository(HotelManagemnetContext context)
        {
            _context = context;
        }
        public Task<IEnumerable<Hotel>> Get()
        {
            throw new NotImplementedException();
        }

        public Task<Hotel> GetById(int id)
        {
            throw new NotImplementedException();
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

        public Task<bool> SaveChangesAsync()
        {
            throw new NotImplementedException();
        }
    }
}

using Hotel_Management.Model.Entity;

namespace Hotel_Management.Repository.Interfaces
{
    public interface IHotelRepository
    {
        Task<IEnumerable<Hotel>> Get();
        Task<Hotel> GetById(int id);
        void Create(Hotel hotel);
        void Update(Hotel hotel);
        Task<bool> SaveChangesAsync();
    }
}

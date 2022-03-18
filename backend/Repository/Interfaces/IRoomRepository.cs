using Hotel_Management.Model.Entity;

namespace Hotel_Management.Repository.Interfaces
{
    public interface IRoomRepository
    {
        Task<IEnumerable<Room>> Get();
        Task<Room> GetById(int id);
        void Create(Room room);
        void Update(Room room);
        void Delete(Room room);
        Task<bool> SaveChangesAsync();
    }
}

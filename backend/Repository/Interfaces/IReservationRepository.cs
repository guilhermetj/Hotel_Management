using Hotel_Management.Model.Entity;

namespace Hotel_Management.Repository.Interfaces
{
    public interface IReservationRepository
    {
        Task<IEnumerable<Reservation>> Get();
        Task<Reservation> GetById(int id);
        Task<Reservation> GetByRoomId(int id);
        void Create(Reservation reservation);
        void Cancel(Reservation reservation);
        Task<bool> SaveChangesAsync();
    }
}

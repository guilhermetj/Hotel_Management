using Hotel_Management.Model.Entity;

namespace Hotel_Management.Repository.Interfaces
{
    public interface IReservationRepository
    {
        Task<IEnumerable<Reservation>> Get();
        Task<Reservation> GetById(int id);
        void Create(Reservation reservation);
        void Update(Reservation reservation);
        Task<bool> SaveChangesAsync();
    }
}

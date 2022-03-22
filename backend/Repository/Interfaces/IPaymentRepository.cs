using Hotel_Management.Model.Entity;

namespace Hotel_Management.Repository.Interfaces
{
    public interface IPaymentRepository
    {
        Task<IEnumerable<Payment>> Get();
        Task<Payment> GetById(int id);
        void Create(Payment payment);
        void Update(Payment payment);
        void Disable(Payment payment);
        Task<bool> SaveChangesAsync();
    }
}

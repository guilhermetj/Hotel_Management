using Hotel_Management.Data;
using Hotel_Management.Model.Entity;
using Hotel_Management.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Hotel_Management.Repository
{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly HotelManagementContext _context;
        public PaymentRepository(HotelManagementContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Payment>> Get()
        {
            return await _context.Payments
                                 .Include(x => x.Reservation).ThenInclude(x => x.Client)
                                 .Include(x => x.Reservation).ThenInclude(x => x.Room).ThenInclude(x => x.Hotel)
                                 .ToListAsync();
        }

        public async Task<Payment> GetById(int id)
        {
            return await _context.Payments
                                    .Include(x => x.Reservation).ThenInclude(x => x.Client)
                                    .Include(x => x.Reservation).ThenInclude(x => x.Room).ThenInclude(x => x.Hotel)
                                    .Where(x => x.Id == id)
                                    .FirstOrDefaultAsync();
        }

        public void Create(Payment payment)
        {
            _context.Add(payment);
        }

        public void Update(Payment payment)
        {
            _context.Update(payment);
        }

        public void Disable(Payment payment)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}

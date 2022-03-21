using Hotel_Management.Data;
using Hotel_Management.Model.Entity;
using Hotel_Management.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Hotel_Management.Repository
{
    public class ClientRepository : IClientRepository
    {
        private readonly HotelManagementContext _context;

        public ClientRepository(HotelManagementContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Client>> Get()
        {
            return await _context.Clients.ToListAsync();
        }

        public async Task<Client> GetById(int id)
        {
            return await _context.Clients
                                    .Where(c => c.Id == id)
                                    .FirstOrDefaultAsync();
        }
        public void Create(Client client)
        {
            _context.Add(client);
        }
        public void Update(Client client)
        {
            _context.Update(client);
        }
        public void Disable(Client client)
        {
            _context.Update(client);
        }
        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}

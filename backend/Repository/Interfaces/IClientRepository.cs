using Hotel_Management.Model.Entity;

namespace Hotel_Management.Repository.Interfaces
{
    public interface IClientRepository
    {
        Task<IEnumerable<Client>> Get();
        Task<Client> GetById(int id);
        void Create(Client client);
        void Update(Client client);
        void Disable(Client client);
        Task<bool> SaveChangesAsync();
    }
}


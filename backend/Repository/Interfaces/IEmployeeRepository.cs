using Hotel_Management.Model.Entity;

namespace Hotel_Management.Repository.Interfaces
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employee>> Get();
        Task<Employee> GetById(int id);
        void Create(Employee employee);
        void Update(Employee employee);
        void Disable(Employee employee);
        Task<bool> SaveChangesAsync();
    }
}

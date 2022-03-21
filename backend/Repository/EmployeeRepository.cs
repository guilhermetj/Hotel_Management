using Hotel_Management.Data;
using Hotel_Management.Model.Entity;
using Hotel_Management.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Hotel_Management.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly HotelManagementContext _context;
        public EmployeeRepository(HotelManagementContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Employee>> Get()
        {
            return await _context.Employees
                                   .Include(x => x.Hotel)
                                   .ToListAsync();
        }

        public async Task<Employee> GetById(int id)
        {
            return await _context.Employees
                                    .Include(x => x.Hotel)
                                    .Where(x => x.Id == id)
                                    .FirstOrDefaultAsync();
        }
        public void Create(Employee employee)
        {
            _context.Add(employee);
        }

        public void Update(Employee employee)
        {
            _context.Update(employee);
        }
        public async Task<bool> SaveChangesAsync()
        {
            return _context.SaveChanges() > 0;
        }

    }
}

using Hotel_Management.Model.Dtos.HotelDtos;
using Hotel_Management.Model.Entity;

namespace Hotel_Management.Model.Dtos.EmployeeDtos
{
    public class EmployeeDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public DateTime? DeletionAt { get; set; }
        public HotelDetailsDto Hotel { get; set; }
    }
}

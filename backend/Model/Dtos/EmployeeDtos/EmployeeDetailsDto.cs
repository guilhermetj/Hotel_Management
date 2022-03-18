namespace Hotel_Management.Model.Dtos.EmployeeDtos
{
    public class EmployeeDetailsDto
    {
        public int Id { get; set; }
        public int Hotel_id { get; set; }
        public Hotel Hotel { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public DateTime? DeletionAt { get; set; }
    }
}

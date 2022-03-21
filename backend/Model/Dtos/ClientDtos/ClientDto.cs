namespace Hotel_Management.Model.Dtos.ClientDtos
{
    public class ClientDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Adress { get; set; }
        public DateTime? DeletionAt { get; set; }
    }
}

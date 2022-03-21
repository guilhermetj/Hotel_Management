namespace Hotel_Management.Model.Entity
{
    public class Client
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Adress { get; set; }
        public DateTime? DeletionAt { get; set; }
    }
}

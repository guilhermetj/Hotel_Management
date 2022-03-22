namespace Hotel_Management.Model.Entity
{
    public class Reservation
    {
        public int Id { get; set; }
        public string Status { get; set; }
        public int Client_id { get; set; }
        public Client Client { get; set; }
        public int Room_id { get; set; }
        public Room Room { get; set; }
        public Payment Payment { get; set; }
    }
}

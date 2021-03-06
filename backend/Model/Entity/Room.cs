namespace Hotel_Management.Model.Entity
{
    public class Room
    {
        public int Id { get; set; }
        public string RoomType { get; set; }
        public decimal Price { get; set; }
        public int Hotel_id { get; set; }
        public Hotel Hotel { get; set; }
        public List<Reservation> Reservation { get; set; }
    }
}

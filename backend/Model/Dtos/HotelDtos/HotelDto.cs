namespace Hotel_Management.Model.Dtos.HotelDtos
{
    public class HotelDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public int NumRooms { get; set; }
        public bool Active { get; set; }
    }
}

using Hotel_Management.Model.Dtos.HotelDtos;
using Hotel_Management.Model.Entity;

namespace Hotel_Management.Model.Dtos.RoomDtos
{
    public class RoomDetailsDto
    {
        public int Id { get; set; }
        public string RoomType { get; set; }
        public decimal Price { get; set; }
        public HotelDto Hotel { get; set; }
    }
}

using Hotel_Management.Model.Dtos.ClientDtos;
using Hotel_Management.Model.Dtos.RoomDtos;

namespace Hotel_Management.Model.Dtos.ReservationDtos
{
    public class ReservationDto
    {
        public string Status { get; set; }
        public ClientDto Client { get; set; }
        public RoomDto Room { get; set; }
    }
}

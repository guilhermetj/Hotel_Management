using Hotel_Management.Model.Dtos.ReservationDtos;
using Hotel_Management.Model.Entity;

namespace Hotel_Management.Model.Dtos.PaymentDtos
{
    public class PaymentDto
    {
        public int Id { get; set; }
        public ReservationDto Reservation { get; set; }
        public decimal MiscCharges { get; set; }
        public decimal Total { get; set; }
        public string PaymentMethod { get; set; }
    }
}

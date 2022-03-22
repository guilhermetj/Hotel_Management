using Hotel_Management.Model.Dtos.ReservationDtos;
using Hotel_Management.Model.Entity;

namespace Hotel_Management.Model.Dtos.PaymentDtos
{
    public class PaymentDetailsDto
    {
        public int Id { get; set; }   
        public int Reservation_id { get; set; }
        public ReservationDetailsDto Reservation { get; set; }
        public decimal MiscCharges { get; set; }
        public decimal Total { get; set; }
        public string PaymentMethod { get; set; }
    }
}

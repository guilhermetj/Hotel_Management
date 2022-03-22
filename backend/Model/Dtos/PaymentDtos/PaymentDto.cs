using Hotel_Management.Model.Entity;

namespace Hotel_Management.Model.Dtos.PaymentDtos
{
    public class PaymentDto
    {
        public int Id { get; set; }
        public Reservation Reservation { get; set; }
        public int MiscCharges { get; set; }
        public int Total { get; set; }
        public string PaymentMethod { get; set; }
    }
}

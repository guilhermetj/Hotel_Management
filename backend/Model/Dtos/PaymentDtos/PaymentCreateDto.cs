namespace Hotel_Management.Model.Dtos.PaymentDtos
{
    public class PaymentCreateDto
    {
        public int Reservation_id { get; set; }
        public decimal MiscCharges { get; set; }
        public decimal Total { get; set; }
        public string PaymentMethod { get; set; }
    }
}

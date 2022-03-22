namespace Hotel_Management.Model.Entity
{
    public class Payment
    {
        public int Id { get; set; }
        public int Reservation_id { get; set; }
        public Reservation Reservation { get; set; }
        public decimal MiscCharges { get; set; }
        public decimal Total { get; set; }
        public string PaymentMethod { get; set; }
    }
}

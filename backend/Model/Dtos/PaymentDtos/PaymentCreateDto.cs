﻿namespace Hotel_Management.Model.Dtos.PaymentDtos
{
    public class PaymentCreateDto
    {
        public int Reservation_id { get; set; }
        public int MiscCharges { get; set; }
        public int Total { get; set; }
        public string PaymentMethod { get; set; }
    }
}
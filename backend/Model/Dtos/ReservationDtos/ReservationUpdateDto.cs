﻿namespace Hotel_Management.Model.Dtos.ReservationDtos
{
    public class ReservationUpdateDto
    {
        public string? Status { get; set; }
        public int? Client_id { get; set; }
        public int? Room_id { get; set; }
    }
}

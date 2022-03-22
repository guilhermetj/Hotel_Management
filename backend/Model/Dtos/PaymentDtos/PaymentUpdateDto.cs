using System.ComponentModel.DataAnnotations;

namespace Hotel_Management.Model.Dtos.PaymentDtos
{
    public class PaymentUpdateDto
    {
        public decimal MiscCharges { get; set; }
        public decimal Total { get; set; }
        public string? PaymentMethod { get; set; }
    }
}

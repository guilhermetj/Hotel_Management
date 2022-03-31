using FluentValidation;
using Hotel_Management.Model.Dtos.PaymentDtos;

namespace Hotel_Management.Validators.PaymentValidator
{
    public class PaymentCreateValidator : AbstractValidator<PaymentCreateDto>
    {
        public PaymentCreateValidator()
        {
            RuleFor(x => x.MiscCharges).NotEmpty().ScalePrecision(2, 10, true);
            RuleFor(x => x.Total).NotEmpty().NotNull().ScalePrecision(2, 10, true);
            RuleFor(x => x.PaymentMethod).NotEmpty().NotNull().Must(PaymentForm).WithMessage("A Forma de pagamento precisa ser Pix, Cartão de credito ou Boleto");
        }

        private bool PaymentForm(string payment)
        {
           return payment == "Boleto" || payment == "Cartão de credito" || payment == "Pix";
        }
    }
}

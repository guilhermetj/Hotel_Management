using FluentValidation;
using Hotel_Management.Model.Dtos.PaymentDtos;

namespace Hotel_Management.Validators.PaymentValidator
{
    public class PaymentUpdateValidator : AbstractValidator<PaymentUpdateDto>
    {
        public PaymentUpdateValidator()
        {
            RuleFor(x => x.MiscCharges).ScalePrecision(2, 10, true);
            RuleFor(x => x.Total).ScalePrecision(2, 10, true);
            RuleFor(x => x.PaymentMethod).Must(PaymentForm).WithMessage("A Forma de pagamento precisa ser Pix, Cartão de credito ou Boleto");
        }
        private bool PaymentForm(string payment)
        {
            return payment == "Boleto" || payment == "Cartão de credito" || payment == "Pix";
        }
    }
}

using FluentValidation;
using Hotel_Management.Model.Dtos.ClientDtos;

namespace Hotel_Management.Validators.ClientValidator
{
    public class ClientCreateValidator : AbstractValidator<ClientCreateDto>
    {
        public ClientCreateValidator()
        {
            RuleFor(x => x.Name).NotEmpty().NotNull().Length(2, 10);
            RuleFor(x => x.LastName).NotEmpty().NotNull().Length(2, 10);
            RuleFor(x => x.Phone).NotEmpty().NotNull().Matches("[2-9][0-9]{10}");
            RuleFor(x => x.Address).NotEmpty().NotNull();
        }
    }
}

using FluentValidation;
using Hotel_Management.Model.Dtos.ClientDtos;

namespace Hotel_Management.Validators.ClientValidator
{
    public class ClientUpdateValidator : AbstractValidator<ClientUpdateDto>
    {
        public ClientUpdateValidator()
        {
            RuleFor(x => x.Name).Length(2, 10);
            RuleFor(x => x.LastName).Length(2, 10);
            RuleFor(x => x.Phone).Matches("[2-9][0-9]{10}");
            RuleFor(x => x.Address).Length(2, 40);
        }
 
    }
}

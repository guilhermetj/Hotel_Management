using FluentValidation;
using Hotel_Management.Model.Dtos.EmployeeDtos;

namespace Hotel_Management.Validators.EmployeeValidator
{
    public class EmployeeCreateValidator : AbstractValidator<EmployeeCreateDto>
    {
        public EmployeeCreateValidator()
        {
            RuleFor(x => x.Name).NotEmpty().NotNull().Length(2,10);
            RuleFor(x => x.LastName).NotEmpty().NotNull().Length(2,10);
            RuleFor(x => x.Phone).NotEmpty().NotNull().Matches("[2-9][0-9]{10}");
        }
    }
}

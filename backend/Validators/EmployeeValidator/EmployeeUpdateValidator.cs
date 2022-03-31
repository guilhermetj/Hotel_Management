using FluentValidation;
using Hotel_Management.Model.Dtos.EmployeeDtos;

namespace Hotel_Management.Validators.EmployeeValidator
{
    public class EmployeeUpdateValidator : AbstractValidator<EmployeeUpdateDto>
    {
        public EmployeeUpdateValidator()
        {
            RuleFor(x => x.Name).Length(2, 10);
            RuleFor(x => x.LastName).Length(2, 10);
            RuleFor(x => x.Phone).Matches("[2-9][0-9]{10}");
        }
    }
}

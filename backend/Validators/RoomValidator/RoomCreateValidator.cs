using FluentValidation;
using Hotel_Management.Model.Dtos.RoomDtos;

namespace Hotel_Management.Validators.RoomValidator
{
    public class RoomCreateValidator : AbstractValidator<RoomCreateDto>
    {
        public RoomCreateValidator()
        {
            RuleFor(x => x.RoomType).NotNull().NotEmpty().Must(RoomTypes).WithMessage("Tipo de quarto precisa ser Standard, Master ou Deluxe");
            RuleFor(x => x.Price).NotNull().NotEmpty().ScalePrecision(2,10,true);
        }

        private bool RoomTypes(string types)
        {
            return types == "Standard" || types == "Master" || types == "Deluxe";
        }
    }
}

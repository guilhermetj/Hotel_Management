using FluentValidation;
using Hotel_Management.Model.Dtos.RoomDtos;

namespace Hotel_Management.Validators.RoomValidator
{
    public class RoomUpdateValidator : AbstractValidator<RoomUpdateDto>
    {
        public RoomUpdateValidator()
        {

            RuleFor(x => x.RoomType).Must(RoomTypes).WithMessage("Tipo de quarto precisa ser Standard, Master ou Deluxe");
            RuleFor(x => x.Price).ScalePrecision(2, 10, true);
        }
        private bool RoomTypes(string types)
        {
                return types == "Standard" || types == "Master" || types == "Deluxe";
        }
    }
}

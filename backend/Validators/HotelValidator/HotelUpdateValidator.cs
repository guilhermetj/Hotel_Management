using FluentValidation;
using Hotel_Management.Model.Dtos.HotelDtos;

namespace Hotel_Management.Validators.HotelValidator
{
    public class HotelUpdateValidator : AbstractValidator<HotelUpdateDto>
    {
        public HotelUpdateValidator()
        {
            RuleFor(x => x.Name).Length(2, 30);
            RuleFor(x => x.Location).Length(2, 10);
            RuleFor(x => x.NumRooms).NotNull().NotEmpty().InclusiveBetween(1, 100);
        }
    }
}

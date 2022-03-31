using FluentValidation;
using Hotel_Management.Model.Dtos.HotelDtos;

namespace Hotel_Management.Validators.HotelValidator
{
    public class HotelCreateValidator : AbstractValidator<HotelCreateDto>
    {
        public HotelCreateValidator()
        {
            RuleFor(x => x.Name).NotNull().NotEmpty().Length(2, 30);
            RuleFor(x => x.Location).NotNull().NotEmpty().Length(2, 10);
            RuleFor(x => x.NumRooms).NotNull().NotEmpty().InclusiveBetween(1, 100);
        }
    }
}

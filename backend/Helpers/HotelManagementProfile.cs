using AutoMapper;
using Hotel_Management.Model.Dtos.HotelDtos;
using Hotel_Management.Model.Entity;

namespace Hotel_Management.Helpers
{
    public class HotelManagementProfile : Profile
    {
        public HotelManagementProfile()
        {
            CreateMap<Hotel, HotelDto>();

            CreateMap<Hotel, HotelDetailsDto>();

            CreateMap<HotelCreateDto, Hotel>();

            CreateMap<HotelUpdateDto, Hotel>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

        }
    }
}

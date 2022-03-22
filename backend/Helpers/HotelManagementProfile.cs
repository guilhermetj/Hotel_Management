using AutoMapper;
using Hotel_Management.Model.Dtos.ClientDtos;
using Hotel_Management.Model.Dtos.EmployeeDtos;
using Hotel_Management.Model.Dtos.HotelDtos;
using Hotel_Management.Model.Dtos.PaymentDtos;
using Hotel_Management.Model.Dtos.ReservationDtos;
using Hotel_Management.Model.Dtos.RoomDtos;
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

            //Rooms

            CreateMap<Room, RoomDto>();

            CreateMap<Room, RoomDetailsDto>();

            CreateMap<RoomCreateDto, Room>();

            CreateMap<RoomUpdateDto, Room>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            //Employee

            CreateMap<Employee, EmployeeDto>();

            CreateMap<Employee, EmployeeDetailsDto>();

            CreateMap<EmployeeCreateDto, Employee>();

            CreateMap<EmployeeUpdateDto, Employee>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            //Clients

            CreateMap<Client, ClientDto>();

            CreateMap<Client, ClientDetailsDto>();

            CreateMap<ClientCreateDto, Client>();

            CreateMap<ClientUpdateDto, Client>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));


            //Reservation

            CreateMap<Reservation, ReservationDto>();

            CreateMap<Reservation, ReservationDetailsDto>();

            CreateMap<ReservationCreateDto, Reservation>();

            CreateMap<ReservationUpdateDto, Reservation>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            //Payment

            CreateMap<Payment, PaymentDto>();

            CreateMap<Payment, PaymentDetailsDto>();

            CreateMap<PaymentCreateDto, Payment>();

            CreateMap<PaymentUpdateDto, Payment>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}

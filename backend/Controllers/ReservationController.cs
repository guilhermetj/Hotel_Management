using AutoMapper;
using Hotel_Management.Model.Dtos.ReservationDtos;
using Hotel_Management.Model.Entity;
using Hotel_Management.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Hotel_Management.Controllers
{
    [ApiController]
    [Route("Api/[controller]")]
    public class ReservationController : ControllerBase
    {
        private readonly IReservationRepository _repository;
        private readonly IMapper _mapper;
        public ReservationController(IReservationRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var reservation = await _repository.Get();

            var reservationReturn = _mapper.Map<IEnumerable<ReservationDto>>(reservation);

            return Ok(reservationReturn);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var reservationBanco = await _repository.GetById(id);
            if(reservationBanco == null) return BadRequest("Reservation not Found");

            var reservationReturn = _mapper.Map<ReservationDto>(reservationBanco);

            return Ok(reservationReturn);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ReservationCreateDto reservationCreateDto)
        {
            var reservationStatus = await _repository.GetByRoomId(reservationCreateDto.Room_id);
            if (reservationStatus != null && reservationStatus.Status == "Reservado")
                 return BadRequest("Room has already been booked");

            var reservation = _mapper.Map<Reservation>(reservationCreateDto);
            reservation.Status = "Reservado";

            _repository.Create(reservation);

            return await _repository.SaveChangesAsync() ? Ok("Reservation created") : BadRequest("Error creating reservation");
        }
        [HttpPut("{id}")] 
        public async Task<IActionResult> Cancel(int id)
        {
            var reservationBanco = await _repository.GetById(id);
            if (reservationBanco == null) return BadRequest("Reservation not Found");

            reservationBanco.Status = "Cancelado";

            _repository.Cancel(reservationBanco);
            return await _repository.SaveChangesAsync() ? Ok("canceled reservation ") : BadRequest("Error canceling reservation");
        }

    }
}

using Hotel_Management.Model.Entity;
using Hotel_Management.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Hotel_Management.Controllers
{
    [ApiController]
    [Route("Api/[controller]")]
    public class HotelController : ControllerBase
    {
        private readonly IHotelRepository _repository;

        public HotelController(IHotelRepository repository)
        {
            _repository = repository;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var hotel = await _repository.Get();

            return Ok(hotel);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {

            var hotel = await _repository.GetById(id);

            return hotel != null ? Ok(hotel) : NotFound("hotel not found");
        }
        [HttpPost]
        public async Task<IActionResult> Add(Hotel hotel)
        {

            _repository.Create(hotel);

            return await _repository.SaveChangesAsync() ? Ok("Hotel created") : BadRequest("Error when creating") ;
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Hotel hotel)
        {

            var hotelBanco = await _repository.GetById(id);
            if (hotelBanco == null) return NotFound("hotel not found");

            hotelBanco.Name = hotel.Name ?? hotelBanco.Name;
            hotelBanco.Location = hotel.Location ?? hotelBanco.Location;
            hotelBanco.NumRooms = hotel.NumRooms;

            _repository.Update(hotelBanco);

            return await _repository.SaveChangesAsync() ? Ok("Hotel updated") : BadRequest("Error when editing");
        }
        [HttpPut("disable/{id}")]
        public async Task<IActionResult> Disable(int id)
        {

            var hotelBanco = await _repository.GetById(id);
            if (hotelBanco == null) return NotFound("hotel not found");

            hotelBanco.Active = false;

            _repository.Update(hotelBanco);

            return await _repository.SaveChangesAsync() ? Ok("Hotel Disabled") : BadRequest("Error when editing");
        }

    }
}

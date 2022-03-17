using AutoMapper;
using Hotel_Management.Model.Dtos.HotelDtos;
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
        private readonly IMapper _mapper;

        public HotelController(IHotelRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var hotel = await _repository.Get();

            var hotelReturn = _mapper.Map<IEnumerable<HotelDto>>(hotel);

            return Ok(hotelReturn);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {

            var hotel = await _repository.GetById(id);

            var hotelReturn = _mapper.Map<HotelDetailsDto>(hotel);

            return hotelReturn != null ? Ok(hotelReturn) : NotFound("hotel not found");
        }
        [HttpPost]
        public async Task<IActionResult> Add(HotelCreateDto hotelCreateDto)
        {
            var hotel = _mapper.Map<Hotel>(hotelCreateDto);

            _repository.Create(hotel);

            return await _repository.SaveChangesAsync() ? Ok("Hotel created") : BadRequest("Error when creating") ;
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, HotelUpdateDto hotelUpdateDto)
        {

            var hotelBanco = await _repository.GetById(id);
            if (hotelBanco == null) return NotFound("hotel not found");

            var hotel = _mapper.Map(hotelUpdateDto, hotelBanco);

            _repository.Update(hotel);

            return await _repository.SaveChangesAsync() ? Ok("Hotel updated") : BadRequest("Error when editing");
        }
        [HttpPut("disable/{id}")]
        public async Task<IActionResult> Disable(int id)
        {

            var hotelBanco = await _repository.GetById(id);
            if (hotelBanco == null) return NotFound("hotel not found");
            if(hotelBanco.Active == true)
            {
                hotelBanco.Active = false;
            }
            else if(hotelBanco.Active == false)
            {
                hotelBanco.Active = true; 
            }
                _repository.Update(hotelBanco);
            return await _repository.SaveChangesAsync() ? Ok("Hotel disabled/activated success") : BadRequest("Error");
        }

    }
}

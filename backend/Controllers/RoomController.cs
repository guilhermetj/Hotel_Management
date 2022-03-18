using AutoMapper;
using Hotel_Management.Model.Dtos.RoomDtos;
using Hotel_Management.Model.Entity;
using Hotel_Management.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Hotel_Management.Controllers
{
    [ApiController]
    [Route("Api/[controller]")]
    public class RoomController : ControllerBase
    {
        private readonly IRoomRepository _repository;
        private readonly IMapper _mapper;

        public RoomController(IRoomRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var room = await _repository.Get();

            var roomReturn = _mapper.Map<IEnumerable<RoomDto>>(room);

            return Ok(roomReturn);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {

            var room = await _repository.GetById(id);

            var roomReturn = _mapper.Map<RoomDetailsDto>(room);

            return roomReturn != null ? Ok(roomReturn) : NotFound("Room not found");
        }
        [HttpPost]
        public async Task<IActionResult> Add(RoomCreateDto roomCreateDto)
        {
            var room = _mapper.Map<Room>(roomCreateDto);

            _repository.Create(room);

            return await _repository.SaveChangesAsync() ? Ok("Room created") : BadRequest("Error when creating");
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, RoomUpdateDto roomUpdateDto)
        {
            var roomBanco = await _repository.GetById(id);
            if (roomBanco == null) return BadRequest("Room not found");

            var room = _mapper.Map(roomUpdateDto, roomBanco);

            _repository.Update(room);

            return await _repository.SaveChangesAsync() ? Ok("Room updated") : BadRequest("Error when updating");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var roomBanco = await _repository.GetById(id);
            if (roomBanco == null) return BadRequest("Room not found");

            _repository.Delete(roomBanco);

            return await _repository.SaveChangesAsync() ? Ok("Room Deleted") : BadRequest("Error when deleting");
        }

    }
}

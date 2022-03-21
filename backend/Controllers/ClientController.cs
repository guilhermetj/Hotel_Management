using AutoMapper;
using Hotel_Management.Model.Dtos.ClientDtos;
using Hotel_Management.Model.Entity;
using Hotel_Management.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Hotel_Management.Controllers
{
    [ApiController]
    [Route("Api/[controller]")]
    public class ClientController : ControllerBase
    {
        private readonly IClientRepository _repository;
        private readonly IMapper _mapper;
        public ClientController(IClientRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var client = await _repository.Get();
            var clientReturn = _mapper.Map<IEnumerable<ClientDto>>(client);

            return Ok(clientReturn);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var clientBanco = await _repository.GetById(id);
            if (clientBanco == null) 
                return BadRequest("Client Not Found");

            var clientReturn = _mapper.Map<ClientDetailsDto>(clientBanco);

            return Ok(clientReturn);
        }
        [HttpPost]
        public async Task<IActionResult> Create(ClientCreateDto clientCreateDto)
        {
            var client = _mapper.Map<Client>(clientCreateDto);

            _repository.Create(client);

            return await _repository.SaveChangesAsync() ? Ok("Client created success") : BadRequest("Error when creating client");
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, ClientUpdateDto clientUpdateDto)
        {
            var clientBanco = await _repository.GetById(id);
            if (clientBanco == null) return BadRequest("Client Not Found");

            var clientReturn = _mapper.Map(clientUpdateDto, clientBanco);

            _repository.Update(clientReturn);

            return await _repository.SaveChangesAsync() ? Ok("Client edited success") : BadRequest("Error when editing client");
        }
        [HttpPut("disable/{id}")]
        public async Task<IActionResult> Update(int id)
        {
            var clientBanco = await _repository.GetById(id);
            if (clientBanco == null) return BadRequest("Client Not Found");

            clientBanco.DeletionAt = DateTime.Now;
            _repository.Update(clientBanco);
            return await _repository.SaveChangesAsync() ? Ok("Client disabled success") : BadRequest("Error when deactivating client");
        }
    }
}

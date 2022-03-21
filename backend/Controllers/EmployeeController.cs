using AutoMapper;
using Hotel_Management.Model.Dtos.EmployeeDtos;
using Hotel_Management.Model.Entity;
using Hotel_Management.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Hotel_Management.Controllers
{
    [ApiController]
    [Route("Api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository _repository;
        private readonly IMapper _mapper;
        public EmployeeController(IEmployeeRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> Get(int id)
        {
            var employee = await _repository.Get();

            var employeeReturn = _mapper.Map<IEnumerable<EmployeeDto>>(employee);

            return Ok(employeeReturn);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var employeebanco = await _repository.GetById(id);
            if (employeebanco == null) return BadRequest("Employee not found");

            var employeeReturn = _mapper.Map<EmployeeDetailsDto>(employeebanco);

            return Ok(employeeReturn);
        }
        [HttpPost]
        public async Task<IActionResult> Create(EmployeeCreateDto employeeCreateDto)
        {
            var employeeReturn = _mapper.Map<Employee>(employeeCreateDto);

            _repository.Create(employeeReturn);

            return await _repository.SaveChangesAsync() ? Ok("Employee created success") : BadRequest("Error when creating employee");
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Create(int id, EmployeeUpdateDto employeeUpdateDto)
        {
            var employeebanco = await _repository.GetById(id);
            if (employeebanco == null) return BadRequest("Employee not found");

            var employeeReturn = _mapper.Map(employeeUpdateDto, employeebanco);

            _repository.Update(employeeReturn);

            return await _repository.SaveChangesAsync() ? Ok("Employee updated success") : BadRequest("Error when updating employee");
        }
        [HttpPut("disable/{id}")]
        public async Task<IActionResult> Disable(int id)
        {
            var employeebanco = await _repository.GetById(id);
            if (employeebanco == null) return BadRequest("Employee not found");

            employeebanco.DeletionAt = DateTime.Now;

            _repository.Disable(employeebanco);

            return await _repository.SaveChangesAsync() ? Ok("Employee disabled success") : BadRequest("Error when deactivating employee");
        }
    }
}

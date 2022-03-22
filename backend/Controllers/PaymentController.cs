using AutoMapper;
using Hotel_Management.Model.Dtos.PaymentDtos;
using Hotel_Management.Model.Entity;
using Hotel_Management.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Hotel_Management.Controllers
{
    [ApiController]
    [Route("Api/[controller]")]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentRepository _repository;
        private readonly IMapper _mapper;
        public PaymentController(IPaymentRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var payment = await _repository.Get();
            var paymentReturn = _mapper.Map<IEnumerable<PaymentDto>>(payment);

            return Ok(paymentReturn);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var paymentBanco = await _repository.GetById(id);
            if (paymentBanco == null) return BadRequest("Payment Not Found");

            var paymentReturn = _mapper.Map<PaymentDetailsDto>(paymentBanco);
            return Ok(paymentReturn);
        }
        [HttpPost]
        public async Task<IActionResult> Create(PaymentCreateDto paymentCreateDto)
        {
            var paymentReturn = _mapper.Map<Payment>(paymentCreateDto);
            _repository.Create(paymentReturn);

            return await _repository.SaveChangesAsync() ? Ok("Created payment") : BadRequest("Error when creating payment");
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, PaymentUpdateDto paymentUpdateDto)
        {
            if (paymentUpdateDto.Total == 0 || paymentUpdateDto.MiscCharges == 0) return BadRequest("Total and MiscCharges can't be 0 ");
            var paymentBanco = await _repository.GetById(id);
            if (paymentBanco == null) return BadRequest("Payment Not Found");

            var paymentReturn = _mapper.Map(paymentUpdateDto, paymentBanco);
            
            _repository.Update(paymentReturn);
            return await _repository.SaveChangesAsync() ? Ok("Editing payement success") : BadRequest("Error when editing payment");
        }

    }
}

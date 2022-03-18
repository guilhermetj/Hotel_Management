using AutoMapper;
using Hotel_Management.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Hotel_Management.Controllers
{
    [ApiController]
    [Route("Api/[controller]")]
    public class RoomController : ControllerBase
    {
        private readonly IHotelRepository _repository;
        private readonly IMapper _mapper;

        public RoomController(IHotelRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        

    }
}

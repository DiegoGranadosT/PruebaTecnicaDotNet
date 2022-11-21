using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PruebaTecnicaDotNet.Server.Models;
using PruebaTecnicaDotNet.Server.Repository;
using PruebaTecnicaDotNet.Shared;

namespace PruebaTecnicaDotNet.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerPhoneController : ControllerBase
    {
        private readonly ICustomerPhoneRepository _repository;
        private readonly IMapper _mapper;

        public CustomerPhoneController(ICustomerPhoneRepository repository, IMapper mapper)
        {
            this._repository = repository;
            this._mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult<List<CustomerPhoneViewModel>>> Get()
        {
            var response = await _repository.GetList();

            return _mapper.Map<List<CustomerPhoneViewModel>>(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerPhoneViewModel>> GetById(int id)
        {
            var response = await _repository.GetById(id);

            return _mapper.Map<CustomerPhoneViewModel>(response);
        }
        
        [HttpGet("customer/{customerId}")]
        public async Task<ActionResult<List<CustomerPhoneViewModel>>> GetByCustomerId(int customerId)
        {
            var response = await _repository.GetByCustomerId(customerId);

            return _mapper.Map<List<CustomerPhoneViewModel>>(response);
        }

        [HttpPost]
        public async Task<ActionResult<CustomerPhoneViewModel>> Post([FromBody] CustomerPhoneViewModel customer)
        {
            var model = _mapper.Map<CustomersPhones>(customer);

            var response = await _repository.Add(model);

            return _mapper.Map<CustomerPhoneViewModel>(response);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<CustomerPhoneViewModel>> Put(int id, [FromBody] CustomerPhoneViewModel customer)
        {
            var model = _mapper.Map<CustomersPhones>(customer);

            var response = await _repository.Update(model);

            return _mapper.Map<CustomerPhoneViewModel>(response);
        }
    }
}

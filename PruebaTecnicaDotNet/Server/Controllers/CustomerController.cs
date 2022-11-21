using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PruebaTecnicaDotNet.Server.Models;
using PruebaTecnicaDotNet.Server.Repository;
using PruebaTecnicaDotNet.Shared;

namespace PruebaTecnicaDotNet.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IRepository<Customers> _repository;
        private readonly IMapper _mapper;

        public CustomerController(IRepository<Customers> repository, IMapper mapper)
        {
            this._repository = repository;
            this._mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<CustomerViewModel>>> Get()
        {
            var response = await _repository.GetList();

            return _mapper.Map<List<CustomerViewModel>>(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerViewModel>> GetById(int id)
        {
            var response = await _repository.GetById(id);

            return _mapper.Map<CustomerViewModel>(response);
        }

        [HttpPost]
        public async Task<ActionResult<CustomerViewModel>> Post(CustomerViewModel customer)
        {
            var model = _mapper.Map<Customers>(customer);

            var response = await _repository.Add(model);

            return _mapper.Map<CustomerViewModel>(response);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<CustomerViewModel>> Put(int id, [FromBody] CustomerViewModel customer)
        {
            var model = _mapper.Map<Customers>(customer);

            var response = await _repository.Update(model);

            return _mapper.Map<CustomerViewModel>(response);
        }

    }
}

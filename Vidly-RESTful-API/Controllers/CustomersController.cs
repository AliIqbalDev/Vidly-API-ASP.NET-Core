using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Vidly_RESTful_API.Dtos;
using Vidly_RESTful_API.Models;
using Vidly_RESTful_API.Services;

namespace Vidly_RESTful_API.Controllers
{
    [Route("api/customers")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly IVidlyRepository _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CustomersController(IVidlyRepository repository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetCustomers()
        {
            var customers = await _repository.GetCustomersAsync();

            var customerToReturn = _mapper.Map<IEnumerable<CustomerDto>>(customers);

            return Ok(customerToReturn);
        }

        [HttpGet("{id}", Name = "GetCustomer")]
        public async Task<IActionResult> GetCustomer(int id)
        {
            var customer = await _repository.GetCustomerAsync(id);

            if (customer == null) return NotFound();

            var customerToReturn = _mapper.Map<CustomerDto>(customer);

            return Ok(customerToReturn);
        }

        [HttpPost]
        public async Task<IActionResult> AddCustomer([FromBody] CustomerForCreationDto customerForCreationDto)
        {
            if (customerForCreationDto == null) return BadRequest();

            var customer = _mapper.Map<Customer>(customerForCreationDto);

            _repository.AddCustomer(customer);
            await _unitOfWork.CompleteAsync();

            var customerToReturn = _mapper.Map<CustomerDto>(customer);

            return CreatedAtRoute("GetCustomer", new {id = customerToReturn.Id}, customerToReturn);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCustomer(int id, [FromBody] CustomerForUpdateDto customerForUpdateDto)
        {
            if (customerForUpdateDto == null) return BadRequest();

            var customer = await _repository.GetCustomerAsync(id);

            if (customer == null) return NotFound();

            _mapper.Map(customerForUpdateDto, customer);

            await _unitOfWork.CompleteAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            var customer = await _repository.GetCustomerAsync(id);

            if (customer == null) return NotFound();

            _repository.DeleteCustomer(customer);

            await _unitOfWork.CompleteAsync();

            return NoContent();
        }
    }
}
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoLinx.Application.Contracts;
using ProjetoLinx.Application.DTO;
using ProjetoLinx.Application.Model;
using System.IO;

namespace ProjetoLinx.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerApplicationService _customerApplicationService;

        public CustomerController(ICustomerApplicationService customerApplicationService)
        {
            _customerApplicationService = customerApplicationService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(CustomerModel), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 400)]
        [ProducesResponseType(typeof(BadHttpRequestException), 500)]
        public async Task<IActionResult> Post([FromBody] CustomerModel customerModel)
        {
            customerModel = await _customerApplicationService.CreateCustomerAsync(customerModel);
            
            return StatusCode(201, new
            {
                Message = "Cliente criado com sucesso",
                CustomerDto = customerModel
            });
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(CustomerDto), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 400)]
        [ProducesResponseType(typeof(BadHttpRequestException), 500)]
        public async Task<IActionResult> Put(Guid id, UpdateCustomer updateCustomer)
        {
            updateCustomer = await _customerApplicationService.UpdateCustomerAsync(id, updateCustomer);
            return StatusCode(200, new
            {
                Message = "Usuario atualizado com sucesso.",
                Customer = updateCustomer
            });
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(CustomerDto), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 400)]
        [ProducesResponseType(typeof(BadHttpRequestException), 500)]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _customerApplicationService.DeleteCustomerAsync(id);
            return StatusCode(200, new { Message = "Usuario deletado com sucesso." });
        }

        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(BadRequestResult), 400)]
        [ProducesResponseType(typeof(BadHttpRequestException), 500)]
        public async Task<IActionResult> GetAll()
        {
            var result = await _customerApplicationService.GetAllCustomerAsync();

            if (result.Count == 0)
                return NoContent();

            return Ok(result);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(BadRequestResult), 400)]
        [ProducesResponseType(typeof(BadHttpRequestException), 500)]
        public async Task<IActionResult> GetByCustomer(Guid id)
        {
            var result = await _customerApplicationService.GetByCustomer(id);

            if (result == null)
                return NoContent();

            return Ok(result);
        }
    }
}

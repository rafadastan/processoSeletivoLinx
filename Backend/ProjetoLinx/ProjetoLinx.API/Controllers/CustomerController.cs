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
        [ProducesResponseType(typeof(CustomerDto), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 400)]
        [ProducesResponseType(typeof(BadHttpRequestException), 500)]
        public async Task<IActionResult> Post([FromBody] CustomerDto customerDto)
        {
            customerDto = await _customerApplicationService.CreateCustomerAsync(customerDto);
            
            return StatusCode(201, new
            {
                Message = "Cliente criado com sucesso",
                CustomerDto = customerDto
            });
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
    }
}

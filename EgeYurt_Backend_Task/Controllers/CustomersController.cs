using EgeYurt_Backend_Task.Entities;
using EgeYurt_Backend_Task.Services.Customers;
using Microsoft.AspNetCore.Mvc;

namespace EgeYurt_Backend_Task.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CustomersController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Add([FromBody]CreateCustomerCommand createCustomerCommand)
        {
            CreateCustomerDto createCustomerDto =await Mediator.Send(createCustomerCommand);
            if (createCustomerDto == null) 
                return NotFound();

            return Ok(createCustomerDto);
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            GetAllCustomerQuery query = new GetAllCustomerQuery();
            IList<Customer> result =await Mediator.Send(query);
            return Ok(result);
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateCustomerCommand updateCustomerCommand)
        {
            UpdateCustomerCommandDto updateCustomerCommandDto=await Mediator.Send(updateCustomerCommand);   
            if(updateCustomerCommandDto == null)
                return NotFound();

            return Ok(updateCustomerCommandDto);
        }
        [HttpPost]
        [Route("{Id}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteCustomerCommand deleteCustomerCommand)
        {
            DeleteCustomerCommandDto deleteCustomerCommandDto = await Mediator.Send(deleteCustomerCommand);
            if (deleteCustomerCommandDto == null)
                return NotFound();

            return Ok(deleteCustomerCommandDto);
        }
    }
}

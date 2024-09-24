using Asp.Versioning;
using CustomerService.Application.Commands.Customer;
using CustomerService.Application.Queries.Customer;
using CustomerService.Common;
using CustomerService.Common.Presentation.ApiResults;
using CustomerService.Contracts.Requests;
using CustomerService.Contracts.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace CustomerService.Admin.Rest.Controllers;

[ApiController]
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]")]
public class CustomerController(ILogger<CustomerController> logger, ISender sender) : ApiControllerBase
{
    private readonly ILogger<CustomerController> _logger = logger;

    [HttpGet("all")]
    public async Task<IActionResult> GetAll()
    {
        return Ok();
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateCustomerRequest request)
    {
        Result<Guid> result = await sender.Send(new CreateCustomerCommand(request.FirstName, request.LastName, request.Email));
        return result.Match<IActionResult>(
           onSuccess: () => Ok(new { result.Value }),
           onFailure: ApiResults.Problem);
    }

    [HttpGet("{customerId:guid}")]
    public async Task<IActionResult> Get([Required] Guid customerId)
    {
        Result<CustomerResponse> result = await sender.Send(new GetCustomerQuery(customerId));
        return result.Match(
           onSuccess: () => CreatedAtAction(nameof(Get), new { result.Value }),
           onFailure: ApiResults.Problem);
    }
}
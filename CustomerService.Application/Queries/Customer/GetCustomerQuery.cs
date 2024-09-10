using CustomerService.Common.Messaging;
using CustomerService.Contracts.Responses;

namespace CustomerService.Application.Queries.Customer;

public record GetCustomerQuery(Guid CustomerId) : IQuery<CustomerResponse>;
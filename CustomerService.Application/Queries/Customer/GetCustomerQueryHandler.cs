﻿using CustomerService.Common;
using CustomerService.Common.Messaging;
using CustomerService.Contracts.Responses;
using CustomerService.Domain.Customers;

namespace CustomerService.Application.Queries.Customer;

public class GetCustomerQueryHandler : IQueryHandler<GetCustomerQuery, CustomerResponse>
{
    public async Task<Result<CustomerResponse>> Handle(GetCustomerQuery request, CancellationToken cancellationToken)
    {
        CustomerResponse? customer = new(Guid.NewGuid(), "Murat Can", "Parlar", "canparlar@hotmail.com");

        if (customer is null)
        {
            return Result.Failure<CustomerResponse>(CustomerErrors.NotFound(request.CustomerId));
        }
        await Task.CompletedTask;
        return customer;
    }
}
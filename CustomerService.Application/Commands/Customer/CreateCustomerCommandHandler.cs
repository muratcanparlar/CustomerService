using CustomerService.Common;
using CustomerService.Common.Messaging;
using CustomerService.Domain.Customers;

namespace CustomerService.Application.Commands.Customer;

public class CreateCustomerCommandHandler : ICommandHandler<CreateCustomerCommand, Guid>
{
    public async Task<Result<Guid>> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;

        if (request.LastName.StartsWith("Par"))
        {
            return Result.Failure<Guid>(CustomerErrors.NotFound(Guid.NewGuid()));
        }
        if (request.LastName.StartsWith("Car2"))
        {
            return Result.Failure<Guid>(CustomerErrors.AlreadyUpdated);
        }
        int a = 0;
        var k = 5 / a;

        var id = Guid.NewGuid();
        return id;
    }
}
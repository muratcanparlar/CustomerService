using CustomerService.Common.Messaging;

namespace CustomerService.Application.Commands.Customer;

public record CreateCustomerCommand(string FirstName, string LastName, string Email) : ICommand<Guid>;
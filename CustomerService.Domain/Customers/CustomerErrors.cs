using CustomerService.Common;

namespace CustomerService.Domain.Customers;

public class CustomerErrors
{
    public static Error NotFound(Guid customerId) =>
             Error.NotFound("Customers.NotFound", $"The customer cannot found");

    public static readonly Error AlreadyUpdated = Error.Problem(
        "Customers.AlreadyUpdated",
        "The customer data is already updated");
}
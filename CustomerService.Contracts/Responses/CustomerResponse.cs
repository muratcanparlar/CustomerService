namespace CustomerService.Contracts.Responses;
public record CustomerResponse(Guid Id, string FirstName, string LastName, string Email);
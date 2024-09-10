using FluentValidation;

namespace CustomerService.Application.Commands.Customer
{
    public class CreateCustomerCommandValidator:AbstractValidator<CreateCustomerCommand>
    {
        public CreateCustomerCommandValidator()
        {
            RuleFor(o=>o.FirstName).NotEmpty().WithMessage($"{nameof(CreateCustomerCommand.FirstName)} required");
        }
    }
}

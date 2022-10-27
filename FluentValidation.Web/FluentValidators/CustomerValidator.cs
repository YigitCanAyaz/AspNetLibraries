using FluentValidation.Web.Models;

namespace FluentValidation.Web.FluentValidators
{
    public class CustomerValidator : AbstractValidator<Customer>
    {
        public CustomerValidator()
        {
            RuleFor(c => c.Name).NotEmpty().WithMessage("Name cannot be null!");
            RuleFor(c => c.Email).NotEmpty().WithMessage("Email cannot be null!").EmailAddress().WithMessage("Email format is not correct!");
            RuleFor(c => c.Age).NotEmpty().WithMessage("Age cannot be null!").InclusiveBetween(18, 60).WithMessage("Age should be between 18 and 60");
        }
    }
}

using FluentValidation.Web.Models;

namespace FluentValidation.Web.FluentValidators
{
    public class CustomerValidator : AbstractValidator<Customer>
    {
        public string NotEmptyMessage { get; } = "{PropertyName} cannot be null!";

        public CustomerValidator()
        {
            RuleFor(c => c.Name).NotEmpty().WithMessage(NotEmptyMessage);
            RuleFor(c => c.Email).NotEmpty().WithMessage(NotEmptyMessage).EmailAddress().WithMessage("Email format is not correct!");
            RuleFor(c => c.Age).NotEmpty().WithMessage(NotEmptyMessage).InclusiveBetween(18, 60).WithMessage("Age should be between 18 and 60");
            RuleFor(c => c.BirthDay).NotEmpty().WithMessage(NotEmptyMessage).Must(c =>
            {
                return DateTime.Now.AddYears(-18) >= c;
            }).WithMessage("Age should be bigger than 18");

            RuleForEach(c => c.Addresses).SetValidator(new AddressValidator());
        }
    }
}

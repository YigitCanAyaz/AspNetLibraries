using FluentValidation.Web.Models;

namespace FluentValidation.Web.FluentValidators
{
    public class AddressValidator : AbstractValidator<Address>
    {
        public string NotEmptyMessage { get; } = "{PropertyName} cannot be null!";

        public AddressValidator()
        {
            RuleFor(a => a.Content).NotEmpty().WithMessage(NotEmptyMessage);
            RuleFor(a => a.Province).NotEmpty().WithMessage(NotEmptyMessage);
            RuleFor(a => a.PostalCode).NotEmpty().WithMessage(NotEmptyMessage);
            RuleFor(a => a.PostalCode).MaximumLength(5).WithMessage("{PropertyName} field should be maximum {MaxLength} character");
        }
    }
}

using FluentValidation;

namespace Samat.EndPoints.WebApi.Controllers.Customers.Models
{
    public class CreateCustomerModelValidator : AbstractValidator<CreateCustomerModel>
    {
        public CreateCustomerModelValidator()
        {
            RuleFor(customer => customer.FirstName)
                .NotEmpty().WithMessage("First name is required.");

            RuleFor(customer => customer.LastName)
                .NotEmpty().WithMessage("Last name is required.");

            RuleFor(customer => customer.NationalCode)
                .NotEmpty().WithMessage("National code is required.")
                .Must(BeValidNationalCode).WithMessage("Invalid national code.");
        }

        private bool BeValidNationalCode(string nationalCode)
        {
    
            return nationalCode.Length == 10;
        }
    }
}
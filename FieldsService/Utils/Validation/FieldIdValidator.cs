using FluentValidation;

namespace FieldsService.Utils.Validation
{
    public class FieldIdValidator : AbstractValidator<double>
    {
        public FieldIdValidator() 
        { 
            RuleFor(id => id)
                .GreaterThanOrEqualTo(0)
                .NotEqual(double.NaN)
                .NotEqual(double.PositiveInfinity);
        }
    }
}

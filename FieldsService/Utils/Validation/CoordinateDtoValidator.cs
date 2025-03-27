using FieldsService.Models.Dtos;
using FluentValidation;

namespace FieldsService.Utils.Validation
{
    public class CoordinateDtoValidator : AbstractValidator<CoordinateDto>
    {
        public CoordinateDtoValidator()
        {
            RuleFor(coordinate => coordinate.Latitude).InclusiveBetween(-90, 90);
            RuleFor(coordinate => coordinate.Longitude).InclusiveBetween(-180, 180);
        }
    }
}

using FieldsService.Models;
using FieldsService.Models.Dtos;
using FieldsService.Models.Views;
using FieldsService.Repositories;
using FieldsService.Utils;
using FieldsService.Utils.Extensions;
using FluentValidation;

namespace FieldsService.Services
{
    public class FieldsService : IFieldsService
    {
        private readonly IFieldsRepository _fieldsRepository;
        private readonly IValidator<CoordinateDto> _coordinateValidator;
        private readonly IValidator<double> _idValidator;

        public FieldsService(IFieldsRepository fieldsRepository, IValidator<CoordinateDto> coordinateValidator, IValidator<double> idValidator)
        {
            _fieldsRepository = fieldsRepository;
            _coordinateValidator = coordinateValidator;
            _idValidator = idValidator;
        }

        public double CalculateDistanceToCenter(CoordinateDto coordinate, double id)
        {
            _idValidator.ValidateAndThrow(id);
            _coordinateValidator.ValidateAndThrow(coordinate);
            
            Field field = _fieldsRepository.FindById(id) ?? throw new KeyNotFoundException($"Fields with id {id} not found");
            Coordinate coordinate1 = coordinate.ToModel();

            return MathHelper.CalculateDistance(coordinate1, field.Center);
        }

        public double GetFieldSize(double id)
        {
            _idValidator.ValidateAndThrow(id);

            Field field = _fieldsRepository.FindById(id) ?? throw new KeyNotFoundException($"Fields with id {id} not found");

            return field.Size;
        }

        public ShortFieldView? FindByCoordinates(CoordinateDto coordinate)
        {
            _coordinateValidator.ValidateAndThrow(coordinate);

            throw new NotImplementedException();
        }

        public IEnumerable<FieldView> GetAll() => _fieldsRepository.GetAll().Select(field => field.ToView()).ToArray();
    }
}

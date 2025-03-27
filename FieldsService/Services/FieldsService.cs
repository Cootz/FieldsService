using Aspose.Gis.Geometries;
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

        public double CalculateDistanceToCenter(DistanceToCenterReqiest reqiest)
        {
            _idValidator.ValidateAndThrow(reqiest.FieldId);
            _coordinateValidator.ValidateAndThrow(reqiest.Coordinate);
            
            Field field = _fieldsRepository.FindById(reqiest.FieldId) ?? throw new KeyNotFoundException($"Fields with id {reqiest.FieldId} not found");
            Coordinate coordinate1 = reqiest.Coordinate.ToModel();

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

            Coordinate coordinateModel = coordinate.ToModel();

            var fields = _fieldsRepository.GetAll();

            foreach (Field field in fields)
            {
                if (MathHelper.IsPointInsidePolygon(coordinateModel, field.Bounderies))
                {
                    return field.ToShortView();
                }
            }

            return null;
        }

        public IEnumerable<FieldView> GetAll() => _fieldsRepository.GetAll().Select(field => field.ToView()).ToArray();
    }
}

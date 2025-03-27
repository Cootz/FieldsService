using FieldsService.Models;
using FieldsService.Models.Dtos;
using FieldsService.Models.Views;
using FieldsService.Repositories;

namespace FieldsService.Services
{
    public class FieldsService : IFieldsService
    {
        private readonly IFieldsRepository _fieldsRepository;

        public FieldsService(IFieldsRepository fieldsRepository) => _fieldsRepository = fieldsRepository;

        public double CalculateDistanceToCenter(CoordinateDto coordinate, int id)
        {
            throw new NotImplementedException();
        }

        public double GetFieldSize(int id)
        {
            throw new NotImplementedException();
        }

        public ShortFieldView? FindByCoordinates(CoordinateDto coordinate)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<FieldView> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}

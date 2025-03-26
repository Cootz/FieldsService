using FieldsService.Models;
using FieldsService.Models.Views;
using FieldsService.Repositories;

namespace FieldsService.Services
{
    public class FieldsService : IFieldsService
    {
        private readonly IFieldsRepository _fieldsRepository;

        public FieldsService(IFieldsRepository fieldsRepository) => _fieldsRepository = fieldsRepository;

        public FieldDistanceToCenterView CalculateDistanceToCenter(Coordinate coordinate, int id)
        {
            throw new NotImplementedException();
        }

        public double CalculateFieldSize(int id)
        {
            throw new NotImplementedException();
        }

        public ShortFieldView? FindByCoordinates(Coordinate coordinate)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<FieldView> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}

using FieldsService.Models;
using FieldsService.Models.Views;

namespace FieldsService.Repositories
{
    public interface IFieldsRepository
    {
        IEnumerable<Field> GetAll();
        Field? FindById(double id);
    }
}
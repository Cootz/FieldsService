using FieldsService.Models.Views;

namespace FieldsService.Repositories
{
    public interface IFieldsRepository
    {
        IEnumerable<FieldView> GetAll();
    }
}
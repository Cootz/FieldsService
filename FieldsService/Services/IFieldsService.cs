using FieldsService.Models;
using FieldsService.Models.Dtos;
using FieldsService.Models.Views;

namespace FieldsService.Services
{
    public interface IFieldsService
    {
        /// <summary>
        /// Get all fields
        /// </summary>
        IEnumerable<FieldView> GetAll();

        /// <summary>
        /// Calculate field size in meters squared
        /// </summary>
        /// <param name="id">Field id</param>
        double GetFieldSize(int id);

        /// <summary>
        /// Calculate distance from given point to the center of the field
        /// </summary>
        double CalculateDistanceToCenter(CoordinateDto coordinate, int id);
        
        /// <summary>
        /// Finds what field given point lies in
        /// </summary>
        /// <returns><see cref="ShortFieldView"/> if point lies in any field, otherwise <see langword="null"/></returns>
        ShortFieldView? FindByCoordinates(CoordinateDto coordinate);
    }
}
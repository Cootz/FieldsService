using FieldsService.Models;
using FieldsService.Models.Dtos;
using FieldsService.Models.Views;
using FieldsService.Services;
using Microsoft.AspNetCore.Mvc;

namespace FieldsService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FieldsController : ControllerBase
    {
        private readonly IFieldsService _fieldsService;

        public FieldsController(IFieldsService fieldsService) => _fieldsService = fieldsService;

        [HttpGet("all")]
        public IActionResult GetAll()
        {
            IEnumerable<FieldView> fields = _fieldsService.GetAll();

            return Ok(fields);
        }

        [HttpGet("size")]
        public IActionResult GetSize([FromRoute] int id)
        {
            double size = _fieldsService.GetFieldSize(id);

            return Ok(size);
        }

        [HttpGet("distance_to_center")]
        public IActionResult GetDistanceToCenter([FromBody] CoordinateDto coordinate, [FromBody] int id)
        {
            double result = _fieldsService.CalculateDistanceToCenter(coordinate, id);

            return Ok(result);
        }

        [HttpGet("by_coordinates")]
        public IActionResult GetByCoordinates([FromBody] CoordinateDto coordinate)
        {
            ShortFieldView? field = _fieldsService.FindByCoordinates(coordinate);

            return field is null ? Ok(false) : Ok(field);
        }
    }
}

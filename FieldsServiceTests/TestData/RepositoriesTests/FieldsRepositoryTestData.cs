using FieldsService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FieldsServiceTests.TestData.RepositoriesTests
{
    public static class FieldsRepositoryTestData
    {
        public static Field TestFieldWithIdOfOne = new()
        {
            Id = 1,
            Name = "м01",
            Size = 100,
            Center = new(41.3380610642585, 45.6962567581079),
            Bounderies = [
                new (41.3346809239899, 45.7074047669366), 
                new (41.3414148034017,45.707543073278), 
                new (41.3414148034017,45.6850638023809), 
                new (41.3347304378091,45.6849600309502), 
                new(41.3346809239899,45.7074047669366)]
        };
    }
}

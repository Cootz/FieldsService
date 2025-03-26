using FieldsService.Models;
using FieldsService.Repositories;
using FieldsService.Services;
using FieldsServiceTests.TestData.RepositoriesTests;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FieldsServiceTests.RepositoriesTests
{
    public class FieldsRepositoryTest
    {
        private readonly FieldsRepositoryOptions _options = new()
        {
            PathToData = Path.Combine(Directory.GetParent(Environment.CurrentDirectory)!.Parent!.Parent!.Parent!.FullName, @"FieldsService\Data") //Get Data forlder for tests
        };

        [Test]
        public void InitializationDoesntThrowTest()
        {
            FieldsRepository repository = new(_options);

            Assert.DoesNotThrow(repository.LoadData);
        }

        [Test]
        public void GetAllFieldsTest()
        { 
            FieldsRepository repository = createFieldsRepository();

            IEnumerable<Field> fields = repository.GetAll();

            Assert.That(fields.Count(), Is.EqualTo(6));
            assertFields(fields.First(), FieldsRepositoryTestData.TestFieldWithIdOfOne);
        }

        private void assertFields(Field current, Field other) => 
            Assert.Multiple(() =>
            {
                Assert.That(current.Id, Is.EqualTo(other.Id));
                Assert.That(current.Name, Is.EqualTo(other.Name));
                Assert.That(current.Size, Is.EqualTo(other.Size));
                Assert.That(current.Center, Is.EqualTo(other.Center));
                Assert.That(current.Bounderies, Is.EqualTo(other.Bounderies));
            });

        private FieldsRepository createFieldsRepository()
        {
            FieldsRepository repository = new(_options);

            repository.LoadData();

            return repository;
        }
    }
}

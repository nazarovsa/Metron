using System.Linq;
using System.Threading.Tasks;
using Metron.Repository.Mongo;
using Xunit;

namespace Metron.Repository.Tests.Mongo
{
    [Collection("MongoRepositoryTest")]
    public sealed class MongoRepositoryTest
    {
        private readonly string _connectionString = "mongodb://127.0.0.1:27017/MongoRepositoryTest";
        
        private readonly MongoModelRepository<TestModel> _repository;
        
        private readonly Metron<TestModel> _metron;

        public MongoRepositoryTest()
        {
            _repository = new MongoModelRepository<TestModel>(new MongoConnection(_connectionString));
            _metron = new Metron<TestModel>(_repository);
        }

        [Fact]
        public async Task Should_add_record_and_get_record()
        {
            var model = new TestModel {UserId = 10};
            await _metron.Add(model);

            var records = await _repository.Get();
            Assert.NotNull(records);
            Assert.NotEmpty(records);
            Assert.Equal(records.First().UserId, model.UserId);
        }
    }
}
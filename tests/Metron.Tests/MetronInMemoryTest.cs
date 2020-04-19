using System;
using System.Threading.Tasks;
using Xunit;

namespace Metron.Tests
{
    [Collection("MetronInMemory")]
    public sealed class MetronInMemoryTest : IClassFixture<InMemoryTestFixture>
    {
        private readonly InMemoryTestFixture _fixture;

        public MetronInMemoryTest(InMemoryTestFixture fixture)
        {
            if (fixture == null)
                throw new ArgumentNullException(nameof(fixture));

            _fixture = fixture;
        }

        [Fact]
        public async Task Add()
        {
            var record = new TestModel
            {
                Action = "push",
                Sender = GetType().FullName
            };

            await _fixture.Metron.Add(record);
            Assert.NotEmpty(_fixture.Repository.Items);
        }

        [Fact]
        public async Task Get()
        {
            var result = await _fixture.Metron.Get();
            Assert.NotNull(result);
            Assert.NotEmpty(result);
        }
    }
}
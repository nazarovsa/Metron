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
        public async Task Should_add()
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
        public async Task Should_get()
        {
            var result = await _fixture.Metron.Get();
            Assert.NotNull(result);
            Assert.NotEmpty(result);
        }

        [Fact]
        public async Task Should_get_with_from_to()
        {
            var result = await _fixture.Metron.Get(DateTimeOffset.UtcNow - TimeSpan.FromHours(3), DateTimeOffset.UtcNow);
            Assert.NotNull(result);
            Assert.NotEmpty(result);
        }
    }
}
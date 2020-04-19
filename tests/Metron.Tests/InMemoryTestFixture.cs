namespace Metron.Tests
{
    public sealed class InMemoryTestFixture
    {
        public InMemoryRepository<TestModel> Repository { get; }

        public Metron<TestModel> Metron { get; }

        public InMemoryTestFixture()
        {
            Repository = new InMemoryRepository<TestModel>();
            Metron = new Metron<TestModel>(Repository);
        }
    }
}
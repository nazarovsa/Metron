using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Autofac;
using Xunit;

namespace Metron.Extensions.Tests
{
    public sealed class TestModel : Model
    {
    }

    public sealed class TestRepository : IModelRepository<TestModel>
    {
        public Task Add(TestModel model, CancellationToken cancellationToken = new CancellationToken())
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyCollection<TestModel>> Get(CancellationToken cancellationToken = new CancellationToken())
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyCollection<TestModel>> Get(DateTimeOffset? @from, DateTimeOffset? to, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
    
    public class MetronExtensionsTest
    {
        [Fact]
        public void Should_register_metron_and_repository_in_container()
        {
            var builder = new ContainerBuilder();

            builder.AddMetronScoped<TestModel, TestRepository>();

            var container = builder.Build();

            var metron = container.Resolve<Metron<TestModel>>();
            Assert.NotNull(metron);
            
            var repo = container.Resolve<IModelRepository<TestModel>>();
            Assert.NotNull(repo);
        }
    }
}
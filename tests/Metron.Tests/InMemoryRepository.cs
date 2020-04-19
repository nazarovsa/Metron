using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Metron.Tests
{
    public sealed class InMemoryRepository<TModel> : IModelRepository<TModel>
    {
        private readonly List<TModel> _items;

        public List<TModel> Items => _items;

        public InMemoryRepository()
        {
            _items = new List<TModel>();
        }

        public Task Add(TModel model, CancellationToken cancellationToken = default)
        {
            _items.Add(model);

            return Task.CompletedTask;
        }

        public Task<IReadOnlyCollection<TModel>> Get(CancellationToken cancellationToken = default)
        {
            return Task.FromResult<IReadOnlyCollection<TModel>>(_items);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Metron.Tests
{
    public sealed class InMemoryRepository<TModel> : IModelRepository<TModel>
        where TModel : Model
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

        public Task<IReadOnlyCollection<TModel>> Get(DateTimeOffset? from, DateTimeOffset? to,
            CancellationToken cancellationToken = default)
        {
            IEnumerable<TModel> query = _items;
            if (from.HasValue)
                query = _items.Where(x => x.CreatedAt >= from);

            if (to.HasValue)
                query = query.Where(x => x.CreatedAt <= to);

            return Task.FromResult<IReadOnlyCollection<TModel>>(query.ToList());
        }

        public Task<long> Count(CancellationToken cancellationToken = default)
        {
            return Task.FromResult<long>(_items.Count);
        }
    }
}
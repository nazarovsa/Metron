using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Metron
{
    public sealed class Metron<TModel> : IModelRepository<TModel>
        where TModel : Model
    {
        private readonly IModelRepository<TModel> _repository;

        public Metron(IModelRepository<TModel> repository)
        {
            if (repository == null)
                throw new ArgumentNullException(nameof(repository));

            _repository = repository;
        }

        public Task Add(TModel model, CancellationToken cancellationToken = default) 
            => _repository.Add(model, cancellationToken);

        public Task<IReadOnlyCollection<TModel>> Get(CancellationToken cancellationToken = default) 
            => _repository.Get(cancellationToken);

        public Task<IReadOnlyCollection<TModel>> Get(DateTimeOffset? from, DateTimeOffset? to, CancellationToken cancellationToken = default)
            => _repository.Get(from, to, cancellationToken);
    }
}
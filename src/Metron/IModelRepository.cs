using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Metron
{
    public interface IModelRepository<TModel> where TModel : Model
    {
        Task Add(TModel model, CancellationToken cancellationToken = default);
        
        Task<IReadOnlyCollection<TModel>> Get(CancellationToken cancellationToken = default);

        Task<IReadOnlyCollection<TModel>> Get(DateTimeOffset? from, DateTimeOffset? to, CancellationToken cancellationToken = default);
    }
}
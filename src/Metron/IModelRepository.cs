using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Metron
{
    public interface IModelRepository<TModel>
    {
        Task Add(TModel model, CancellationToken cancellationToken = default);
        
        Task<IReadOnlyCollection<TModel>> Get(CancellationToken cancellationToken = default);
    }
}
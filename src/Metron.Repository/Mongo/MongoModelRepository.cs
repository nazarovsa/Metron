using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace Metron.Repository.Mongo
{
    public sealed class MongoModelRepository<TModel> : IModelRepository<TModel>
    {
        private readonly MongoConnection _connection;

        public MongoModelRepository(MongoConnection connection)
        {
            if (connection == null)
                throw new ArgumentNullException(nameof(connection));

            _connection = connection;
        }

        public async Task Add(TModel model, CancellationToken cancellationToken = default)
        {
            var collection = _connection.GetCollection<TModel>(GetCollectionName());
            await collection.InsertOneAsync(model, new InsertOneOptions(), cancellationToken);
        }

        public async Task<IReadOnlyCollection<TModel>> Get(CancellationToken cancellationToken = default)
        {
            var collection = _connection.GetCollection<TModel>(GetCollectionName());
            var result = await collection
                .FindAsync(_ => true, cancellationToken: cancellationToken)
                .Result
                .ToListAsync(cancellationToken);

            return result;
        }

        private string GetCollectionName()
        {
            return $"Metron-{typeof(TModel).Name}";
        }
    }
}
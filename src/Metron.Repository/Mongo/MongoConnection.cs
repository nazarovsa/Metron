using System;
using System.Threading;
using MongoDB.Driver;

namespace Metron.Repository.Mongo
{
    public class MongoConnection
    {
        private readonly Lazy<IMongoDatabase> _database;

        public MongoConnection(string connectionString)
        {
            _database = new Lazy<IMongoDatabase>(
                () => GetDatabase(connectionString), LazyThreadSafetyMode.ExecutionAndPublication);
        }

        public IMongoDatabase Database => _database.Value;

        private static IMongoDatabase GetDatabase(string connectionString)
        {
            var client = new MongoClient(connectionString);
            var url = new MongoUrl(connectionString);

            return client.GetDatabase(url.DatabaseName);
        }

        public IMongoCollection<T> GetCollection<T>(string name)
        {
            return Database.GetCollection<T>(name);
        }
    }
}
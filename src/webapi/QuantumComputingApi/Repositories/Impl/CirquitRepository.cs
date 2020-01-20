using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using QuantumComputingApi.Daos;
using MongoDB.Driver;
using QuantumComputingApi.Properties;
using Microsoft.Extensions.Options;

namespace QuantumComputingApi.Repositories.Impl {
    public class CirquitRepository : ICirquitRepository {

        IMongoCollection<CirquitDao> _cirquitCollection;
        DatabaseSettings _databaseSettings;

        public CirquitRepository(IOptions<DatabaseSettings> opsettings) {
            _databaseSettings = opsettings.Value;

            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);

            _cirquitCollection = database.GetCollection<CirquitDao>(_databaseSettings.CirquitCollectionName);
        }

        public async Task CreateCirquit(CirquitDao cirquit) {
            await _cirquitCollection.InsertOneAsync(cirquit);
        }

        public async Task<bool> DeleteCirquit(Guid Uuid) {
            var res = await _cirquitCollection.DeleteOneAsync(cirquitDao => cirquitDao.Uuid == Uuid);
            
            return res.IsAcknowledged;
        }

        public async Task<IEnumerable<CirquitDao>> FindAllCirquits() {
            return ( await _cirquitCollection.FindAsync(dao => true)).ToList();
        }

        public async Task<CirquitDao> FindCirquit(Guid Uuid) {
            return (await _cirquitCollection.FindAsync(cirquitDao => cirquitDao.Uuid == Uuid)).FirstOrDefault();
        }

        public async Task<bool> UpdateCirquit(Guid Uuid, CirquitDao cirquit) {
            var filter = Builders<CirquitDao>.Filter.Eq("Uuid", Uuid);
            var update = Builders<CirquitDao>.Update.Set("DtoString", cirquit.DtoString);

            var res = await _cirquitCollection.UpdateOneAsync(filter, update);

            return res.IsAcknowledged;
        }
    }
}
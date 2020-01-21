using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using QuantumComputingApi.Daos;
using QuantumComputingApi.Properties;

namespace QuantumComputingApi.Repositories.Impl {
    public class CircuitRepository : ICircuitRepository {

        IMongoCollection<CircuitDao> _circuitCollection;
        DatabaseSettings _databaseSettings;

        public CircuitRepository(IOptions<DatabaseSettings> opsettings) {
            _databaseSettings = opsettings.Value;

            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);

            _circuitCollection = database.GetCollection<CircuitDao>(_databaseSettings.CircuitCollectionName);
        }

        public async Task CreateCircuit(CircuitDao circuit) {
            await _circuitCollection.InsertOneAsync(circuit);
        }

        public async Task<bool> DeleteCircuit(Guid Uuid) {
            var res = await _circuitCollection.DeleteOneAsync(circuitDao => circuitDao.Uuid == Uuid);

            return res.IsAcknowledged;
        }

        public async Task<IEnumerable<CircuitDao>> FindAllCircuits() {
            return (await _circuitCollection.FindAsync(dao => true)).ToList();
        }

        public async Task<CircuitDao> FindCircuit(Guid Uuid) {
            return (await _circuitCollection.FindAsync(circuitDao => circuitDao.Uuid == Uuid)).FirstOrDefault();
        }

        public async Task<bool> UpdateCircuit(Guid Uuid, CircuitDao circuit) {
            var filter = Builders<CircuitDao>.Filter.Eq("Uuid", Uuid);

            var update = Builders<CircuitDao>
                .Update
                .Set("Elements", circuit.Elements)
                .Set("Connections", circuit.Connections);

            var res = await _circuitCollection.UpdateOneAsync(filter, update);

            return res.IsAcknowledged;
        }
    }
}
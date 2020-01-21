using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace QuantumComputingApi.Daos {
    public class CircuitDao {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public Guid Uuid;

        public IEnumerable<CircuitElementDao> Elements { get; set; }
        public IEnumerable<ConnectionDao> Connections { get; set; }
    }
}
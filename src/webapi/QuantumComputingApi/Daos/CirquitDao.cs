using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace QuantumComputingApi.Daos {
    public class CirquitDao {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string DtoString;
        public Guid Uuid;
    }
}
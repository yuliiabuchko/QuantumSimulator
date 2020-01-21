using MongoDB.Bson.Serialization.Attributes;

namespace QuantumComputingApi.Daos {
    [BsonKnownTypes(typeof(GateDao), typeof(RegisterDao))]
    public class CircuitElementDao {
        public string Type { get; set; }
        public string Id { get; set; }
        public int? InputCount { get; set; }
        public int? OutputCount { get; set; }
    }
}
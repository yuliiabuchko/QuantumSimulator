using System.Numerics;
using Newtonsoft.Json;

namespace QuantumComputingApi.Dtos.Impl.CamelCase.Helpers {
    public class GateDto : IGageDto {
        [JsonProperty(PropertyName = "matrixGate")]
        public Complex[, ] MatrixGate { get; set; }
        

        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }


        [JsonProperty(PropertyName = "inputCount")]
        public int? InputCount { get; set; }


        [JsonProperty(PropertyName = "outputCount")]
        public int? OutputCount { get; set; }
    }
}
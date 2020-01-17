using System.Numerics;
using Newtonsoft.Json;

namespace QuantumComputingApi.Dtos.Impl.SnakeCase.Helpers {
    public class GateDto : IGageDto {
        [JsonProperty(PropertyName = "matrix_gate")]
        public Complex[, ] MatrixGate { get; set; }
        

        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }


        [JsonProperty(PropertyName = "input_count")]
        public int? InputCount { get; set; }


        [JsonProperty(PropertyName = "output_count")]
        public int? OutputCount { get; set; }
    }
}
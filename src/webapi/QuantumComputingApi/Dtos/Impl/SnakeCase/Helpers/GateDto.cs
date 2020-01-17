using System.Numerics;
using Newtonsoft.Json;

namespace QuantumComputingApi.Dtos.Impl.SnakeCase.Helpers {
    public class GateDto : CirquitElementDto, IGageDto {
        [JsonProperty(PropertyName = "matrix_gate")]
        public Complex[, ] MatrixGate { get; set; }
    }
}
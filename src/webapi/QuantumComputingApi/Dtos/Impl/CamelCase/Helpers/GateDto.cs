using System.Numerics;
using Newtonsoft.Json;

namespace QuantumComputingApi.Dtos.Impl.CamelCase.Helpers {
    public class GateDto : CirquitElementDto, IGageDto {
        [JsonProperty(PropertyName = "matrixGate")]
        public Complex[, ] MatrixGate { get; set; }

    }
}
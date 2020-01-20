using System.Numerics;
using Newtonsoft.Json;

namespace QuantumComputingApi.Dtos.Impl.CamelCase.Helpers {
    public class GateDto : CircuitElementDto, IGageDto {
        [JsonProperty(PropertyName = "gateName")]
        public string GateName { get; set; }

    }
}
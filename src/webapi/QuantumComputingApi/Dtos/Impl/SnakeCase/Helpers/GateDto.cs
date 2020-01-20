using System.Numerics;
using Newtonsoft.Json;

namespace QuantumComputingApi.Dtos.Impl.SnakeCase.Helpers {
    public class GateDto : CircuitElementDto, IGageDto {
        
        [JsonProperty(PropertyName = "gate_name")]
        public string GateName { get ; set; }
    }
}
using Newtonsoft.Json;

namespace QuantumComputingApi.Dtos.Impl.CamelCase {
    public class CircuitResultDto : ICircuitResultDto {
        [JsonProperty(PropertyName = "resultingRegister")]
        public IRegisterDto ResultingRegister { get; set; }
    }
}
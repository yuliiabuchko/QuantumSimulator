using Newtonsoft.Json;

namespace QuantumComputingApi.Dtos.Impl.SnakeCase {
    public class CircuitResultDto : ICircuitResultDto {
        [JsonProperty(PropertyName = "resulting_register")]
        public IRegisterDto ResultingRegister { get; set; }
    }
}
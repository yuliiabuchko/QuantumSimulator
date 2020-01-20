using Newtonsoft.Json;
using QuantumComputingApi.Dtos.Impl.SnakeCase.Helpers;

namespace QuantumComputingApi.Dtos.Impl.SnakeCase {
    public class CircuitResultDto : ICircuitResultDto {
        [JsonProperty(PropertyName = "resulting_register")]
        public IRegisterDto ResultingRegister { get; set; }
    }
}
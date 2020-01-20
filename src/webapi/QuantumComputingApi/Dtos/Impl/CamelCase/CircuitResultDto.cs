using Newtonsoft.Json;
using QuantumComputingApi.Dtos.Impl.CamelCase.Helpers;

namespace QuantumComputingApi.Dtos.Impl.CamelCase {
    public class CircuitResultDto : ICircuitResultDto {
        [JsonProperty(PropertyName = "resultingRegister")]
        public IRegisterDto ResultingRegister { get; set; }
    }
}
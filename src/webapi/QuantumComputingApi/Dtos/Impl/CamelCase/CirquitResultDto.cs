using Newtonsoft.Json;
using QuantumComputingApi.Dtos.Impl.CamelCase.Helpers;

namespace QuantumComputingApi.Dtos.Impl.CamelCase {
    public class CirquitResultDto : ICirquitResultDto<QubitDto, RegisterDto> {
        [JsonProperty(PropertyName = "resultingRegister")]
        public RegisterDto ResultingRegister { get; set; }
    }
}
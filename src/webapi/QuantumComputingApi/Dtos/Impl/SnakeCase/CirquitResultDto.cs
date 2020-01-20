using Newtonsoft.Json;
using QuantumComputingApi.Dtos.Impl.SnakeCase.Helpers;

namespace QuantumComputingApi.Dtos.Impl.SnakeCase {
    public class CirquitResultDto : ICirquitResultDto<QubitDto, RegisterDto> {
        [JsonProperty(PropertyName = "resulting_register")]
        public RegisterDto ResultingRegister { get; set; }
    }
}
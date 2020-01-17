using Newtonsoft.Json;

namespace QuantumComputingApi.Dtos.Impl.SnakeCase {
    public class CirquitResultDto : ICirquitResultDto {
        [JsonProperty(PropertyName = "resulting_register")]
        public IRegisterDto ResultingRegister { get; set; }
    }
}
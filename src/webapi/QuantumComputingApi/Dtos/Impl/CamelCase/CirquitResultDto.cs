using Newtonsoft.Json;

namespace QuantumComputingApi.Dtos.Impl.CamelCase {
    public class CirquitResultDto : ICirquitResultDto {
        [JsonProperty(PropertyName = "resultingRegister")]
        public IRegisterDto ResultingRegister { get; set; }
    }
}
using System.Collections.Generic;
using Newtonsoft.Json;

namespace QuantumComputingApi.Dtos.Impl.CamelCase.Helpers {
    public class RegisterDto : IRegisterDto {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "inputCount")]
        public int? InputCount { get; set; }

        [JsonProperty(PropertyName = "outputCount")]
        public int? OutputCount { get; set; }

        [JsonProperty(PropertyName = "qubits")]
        public IEnumerable<IQubitDto> Qubits { get; set; }
    }
}
using System.Collections.Generic;
using Newtonsoft.Json;

namespace QuantumComputingApi.Dtos.Impl.SnakeCase.Helpers {
    public class RegisterDto : IRegisterDto {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "input_count")]
        public int? InputCount { get; set; }

        [JsonProperty(PropertyName = "output_count")]
        public int? OutputCount { get; set; }

        [JsonProperty(PropertyName = "qubits")]
        public IEnumerable<IQubitDto> Qubits { get; set; }
    }
}
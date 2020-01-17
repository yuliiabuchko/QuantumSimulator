using System.Numerics;
using Newtonsoft.Json;

namespace QuantumComputingApi.Dtos.Impl.CamelCase.Helpers {
    public class QubitDto : IQubitDto {
        [JsonProperty(PropertyName = "oneAmplitude")]
        public Complex OneAmplitude { get; set; }

        [JsonProperty(PropertyName = "zeroAmplitude")]
        public Complex ZeroAmplitude { get; set; }
    }
}
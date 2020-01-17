using System.Numerics;
using Newtonsoft.Json;

namespace QuantumComputingApi.Dtos.Impl.SnakeCase.Helpers {
    public class QubitDto : IQubitDto {
        [JsonProperty(PropertyName = "one_amplitude")]
        public Complex OneAmplitude { get; set; }

        [JsonProperty(PropertyName = "zero_amplitude")]
        public Complex ZeroAmplitude { get; set; }
    }
}
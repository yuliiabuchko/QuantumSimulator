using System.Numerics;
using Newtonsoft.Json;

namespace QuantumComputingApi.Dtos.Impl.CamelCase.Helpers {
    public class QubitDto : IQubitDto {
        [JsonProperty(PropertyName = "oneAmplitude")]
        public IComplexDto OneAmplitude { get; set; }

        [JsonProperty(PropertyName = "zeroAmplitude")]
        public IComplexDto ZeroAmplitude { get; set; }
    }
}
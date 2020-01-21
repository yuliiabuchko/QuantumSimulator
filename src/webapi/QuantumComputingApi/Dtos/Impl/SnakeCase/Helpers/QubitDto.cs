using System.Numerics;
using Newtonsoft.Json;

namespace QuantumComputingApi.Dtos.Impl.SnakeCase.Helpers {
    public class QubitDto : IQubitDto {
        [JsonProperty(PropertyName = "one_amplitude")]
        public IComplexDto OneAmplitude { get; set; }

        [JsonProperty(PropertyName = "zero_amplitude")]
        public IComplexDto ZeroAmplitude { get; set; }
    }
}
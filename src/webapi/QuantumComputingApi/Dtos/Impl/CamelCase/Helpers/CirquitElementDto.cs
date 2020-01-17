using Newtonsoft.Json;

namespace QuantumComputingApi.Dtos.Impl.CamelCase.Helpers {
    public class CirquitElementDto : ICirquitElementDto {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "inputCount")]
        public int? InputCount { get; set; }

        [JsonProperty(PropertyName = "outputCount")]
        public int? OutputCount { get; set; }

        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }
    }
}
using System.Collections.Generic;
using Newtonsoft.Json;
using QuantumComputingApi.Dtos.Impl.SnakeCase.Helpers;

namespace QuantumComputingApi.Dtos.Impl.SnakeCase {
    public class CircuitDto : ICircuitDto {
        [JsonProperty(PropertyName = "elements")]
        public IEnumerable<ICircuitElementDto> Elements { get; set; }

        [JsonProperty(PropertyName = "connections")]
        public IEnumerable<IConnectionDto> Connections { get; set; }
    }
}
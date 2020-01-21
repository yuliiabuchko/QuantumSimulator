using System.Collections.Generic;
using Newtonsoft.Json;

namespace QuantumComputingApi.Dtos.Impl.CamelCase {
    public class CircuitDto : ICircuitDto
    {

        [JsonProperty(PropertyName = "elements")]
        public IEnumerable<ICircuitElementDto> Elements { get; set; }

        [JsonProperty(PropertyName = "connections")]
        public IEnumerable<IConnectionDto> Connections { get; set; }
    }
}
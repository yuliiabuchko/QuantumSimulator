using System.Collections.Generic;
using Newtonsoft.Json;

namespace QuantumComputingApi.Dtos.Impl.SnakeCase {
    public class CirquitDto : ICirquitDto {
        [JsonProperty(PropertyName = "elements")]
        public IEnumerable<ICirquitElementDto> Elements { get; set; }

        [JsonProperty(PropertyName = "connections")]
        public IEnumerable<IConnectionDto> Connections { get; set; }
    }
}
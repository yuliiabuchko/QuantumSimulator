using System.Collections.Generic;
using Newtonsoft.Json;

namespace QuantumComputingApi.Dtos.Impl.CamelCase.Helpers {
    public class ConnectionDto : IConnectionDto {
        [JsonProperty(PropertyName = "idLeft")]
        public string IdLeft { get; set; }

        [JsonProperty(PropertyName = "leftEntries")]
        public IEnumerable<int?> LeftEntries { get; set; }

        [JsonProperty(PropertyName = "idRight")]
        public string IdRight { get; set; }

        [JsonProperty(PropertyName = "rightEntries")]
        public IEnumerable<int?> RightEntries { get; set; }
    }
}
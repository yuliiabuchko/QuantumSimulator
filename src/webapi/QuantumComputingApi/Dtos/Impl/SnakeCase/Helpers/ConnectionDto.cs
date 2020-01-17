using System.Collections.Generic;
using Newtonsoft.Json;

namespace QuantumComputingApi.Dtos.Impl.SnakeCase.Helpers {
    public class ConnectionDto : IConnectionDto {
        [JsonProperty(PropertyName = "id_left")]
        public string IdLeft { get; set; }

        [JsonProperty(PropertyName = "left_entries")]
        public IEnumerable<int?> LeftEntries { get; set; }

        [JsonProperty(PropertyName = "id_right")]
        public string IdRight { get; set; }

        [JsonProperty(PropertyName = "right_entries")]
        public IEnumerable<int?> RightEntries { get; set; }
    }
}
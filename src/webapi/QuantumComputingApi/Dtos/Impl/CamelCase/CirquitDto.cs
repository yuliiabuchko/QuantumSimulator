using System.Collections.Generic;
using Newtonsoft.Json;
using QuantumComputingApi.Dtos.Impl.CamelCase.Helpers;

namespace QuantumComputingApi.Dtos.Impl.CamelCase {
    public class CirquitDto : ICirquitDto<CirquitElementDto, ConnectionDto> {

        [JsonProperty(PropertyName = "elements")]
        public IEnumerable<CirquitElementDto> Elements { get; set; }

        [JsonProperty(PropertyName = "connections")]
        public IEnumerable<ConnectionDto> Connections { get; set; }
    }
}
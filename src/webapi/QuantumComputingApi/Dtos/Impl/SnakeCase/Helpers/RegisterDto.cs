using System.Collections.Generic;
using Newtonsoft.Json;

namespace QuantumComputingApi.Dtos.Impl.SnakeCase.Helpers {
    public class RegisterDto :CirquitElementDto, IRegisterDto<QubitDto> {

        [JsonProperty(PropertyName = "qubits")]
        public IEnumerable<QubitDto> Qubits { get; set; }
    }
}
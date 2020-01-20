using System.Collections.Generic;
using Newtonsoft.Json;

namespace QuantumComputingApi.Dtos.Impl.CamelCase.Helpers {
    public class RegisterDto : CircuitElementDto, IRegisterDto {

        [JsonProperty(PropertyName = "qubits")]
        public IEnumerable<IQubitDto> Qubits { get; set; }
    }
}
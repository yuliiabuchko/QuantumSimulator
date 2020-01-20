using System.Collections.Generic;
using Newtonsoft.Json;

namespace QuantumComputingApi.Dtos.Impl.SnakeCase.Helpers {
    public class RegisterDto :CircuitElementDto, IRegisterDto {

        [JsonProperty(PropertyName = "qubits")]
        public IEnumerable<IQubitDto> Qubits { get; set; }
    }
}
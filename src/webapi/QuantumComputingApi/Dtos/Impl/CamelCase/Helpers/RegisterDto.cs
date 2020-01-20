using System.Collections.Generic;
using Newtonsoft.Json;

namespace QuantumComputingApi.Dtos.Impl.CamelCase.Helpers {
    public class RegisterDto : CirquitElementDto, IRegisterDto<QubitDto> {

        [JsonProperty(PropertyName = "qubits")]
        public IEnumerable<QubitDto> Qubits { get; set; }
    }
}
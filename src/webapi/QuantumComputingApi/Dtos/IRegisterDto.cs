using System.Collections.Generic;

namespace QuantumComputingApi.Dtos {
    public interface IRegisterDto : ICircuitElementDto {
        IEnumerable<IQubitDto> Qubits { get; set; }
    }
}
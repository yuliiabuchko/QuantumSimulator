using System.Collections.Generic;

namespace QuantumComputingApi.Dtos {
    public interface IRegisterDto : ICirquitElementDto {
        IEnumerable<IQubitDto> Qubits { get; set; }
    }
}
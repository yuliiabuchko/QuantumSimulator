using System.Collections.Generic;

namespace QuantumComputingApi.Dtos {
    public interface IRegisterDto<T> : ICirquitElementDto
    where T : IQubitDto {
        IEnumerable<T> Qubits { get; set; }
    }
}
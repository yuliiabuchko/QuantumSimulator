using System.Collections.Generic;

namespace QuantumComputingApi.Dtos {
    public interface ICircuitDto
    {
        IEnumerable<ICircuitElementDto> Elements { get; }
        IEnumerable <IConnectionDto> Connections { get; }
    }
}
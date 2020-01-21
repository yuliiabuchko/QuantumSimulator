using System.Collections.Generic;

namespace QuantumComputingApi.Dtos {
    public interface ICircuitDto {
        IEnumerable<ICircuitElementDto> Elements { get; set; }
        IEnumerable<IConnectionDto> Connections { get; set; }
    }
}
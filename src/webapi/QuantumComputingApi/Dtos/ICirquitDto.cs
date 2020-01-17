using System.Collections.Generic;

namespace QuantumComputingApi.Dtos {
    public interface ICirquitDto {
        IEnumerable<ICirquitElementDto> Elements { get; set; }
        IEnumerable <IConnectionDto> Connections {get; set; }
    }
}
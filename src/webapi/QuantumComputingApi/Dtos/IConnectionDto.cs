using System.Collections.Generic;

namespace QuantumComputingApi.Dtos {
    public interface IConnectionDto {
        string IdLeft { get; set; }
        IEnumerable<int?> LeftEntries { get; set; }
        string IdRight { get; set; }
        IEnumerable<int?> RightEntries { get; set; }
    }
}
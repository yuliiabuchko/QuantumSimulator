using System.Numerics;

namespace QuantumComputingApi.Dtos {
    public interface IGageDto : ICirquitElementDto {
        Complex [,] MatrixGate { get; set; }
    }
}
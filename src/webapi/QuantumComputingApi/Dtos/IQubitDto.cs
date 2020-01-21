using System.Numerics;

namespace QuantumComputingApi.Dtos {
    public interface IQubitDto {
        IComplexDto OneAmplitude { get; set; }
        IComplexDto ZeroAmplitude { get; set; }
    }
}
using System.Numerics;

namespace QuantumComputingApi.Dtos {
    public interface IQubitDto {
        Complex OneAmplitude { get; set; }
        Complex ZeroAmplitude { get; set; }
    }
}
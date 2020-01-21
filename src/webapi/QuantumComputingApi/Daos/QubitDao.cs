using System.Numerics;

namespace QuantumComputingApi.Daos {
    public class QubitDao {
        public ComplexDao OneAmplitude { get; set; }
        public ComplexDao ZeroAmplitude { get; set; }
    }
}
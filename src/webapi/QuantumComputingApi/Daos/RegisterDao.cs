using System.Collections.Generic;

namespace QuantumComputingApi.Daos
{
    public class RegisterDao : CircuitElementDao
    {
        public IEnumerable<QubitDao> Qubits { get; set; }
    }
}
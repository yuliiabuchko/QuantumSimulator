using System.Collections.Generic;
using System.Numerics;
using MathNet.Numerics.LinearAlgebra;
using QuantumComputing;

namespace Lachesis.QuantumComputing
{
    public abstract class QuantumRegisterProducerBase
    {
        public abstract QuantumRegisterInterface ProduceRegister(params Complex[] array);
        public abstract QuantumRegisterInterface ProduceRegister(IEnumerable<Complex> enumerable);
        public abstract QuantumRegisterInterface ProduceRegister(Vector<Complex> register);
    }
}
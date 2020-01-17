using System.Collections.Generic;
using System.Numerics;
using MathNet.Numerics.LinearAlgebra;
using QuantumComputing;

namespace Lachesis.QuantumComputing
{
    class QuantumRegisterVectorProducer : QuantumRegisterProducerBase
    {
        public override QuantumRegisterInterface ProduceRegister(params Complex[] array)
        {
            return new QuantumRegisterVector(array);
        }
        
        public override QuantumRegisterInterface ProduceRegister(IEnumerable<Complex> enumerable)
        {
            return new QuantumRegisterVector(enumerable);
        }
        
        public override QuantumRegisterInterface ProduceRegister(Vector<Complex> register)
        {
            return new QuantumRegisterVector(register);
        }
    }
}
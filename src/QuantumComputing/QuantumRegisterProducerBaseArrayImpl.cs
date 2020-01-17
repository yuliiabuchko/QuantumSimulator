using System.Collections.Generic;
using System.Numerics;
using MathNet.Numerics.LinearAlgebra;

namespace Lachesis.QuantumComputing
{
    class QuantumRegisterProducerBaseArrayImpl : QuantumRegisterProducerBase
    {
        public override QuantumRegisterInterface ProduceRegister(params Complex[] array)
        {
            return new QuantumRegisterArray(array);
        }
        
        public override QuantumRegisterInterface ProduceRegister(IEnumerable<Complex> enumerable)
        {
            return new QuantumRegisterArray(enumerable);
        }
        
        public override QuantumRegisterInterface ProduceRegister(Vector<Complex> register)
        {
            return new QuantumRegisterArray(register);
        }
    }
}
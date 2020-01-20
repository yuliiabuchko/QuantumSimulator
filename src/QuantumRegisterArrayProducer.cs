using System.Collections.Generic;
using System.Numerics;
using MathNet.Numerics.LinearAlgebra;

namespace Lachesis.QuantumComputing
{
    class QuantumRegisterArrayProducer : QuantumRegisterProducerBase
    {
        public override QuantumRegisterAbstract ProduceRegister(params Complex[] array)
        {
            return new QuantumRegisterArray(array);
        }
        
        public override QuantumRegisterAbstract ProduceRegister(IEnumerable<Complex> enumerable)
        {
            return new QuantumRegisterArray(enumerable);
        }
        
        public override QuantumRegisterAbstract ProduceRegister(Vector<Complex> register)
        {
            return new QuantumRegisterArray(register);
        }
    }
}
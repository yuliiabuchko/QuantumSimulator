using System.Collections.Generic;
using System.Numerics;
using MathNet.Numerics.LinearAlgebra;

namespace Lachesis.QuantumComputing
{
    public class QuantumRegisterArrayProducer : QuantumRegisterProducerBase
    {
        public override QuantumRegisterAbstract ProduceRegister(Complex zeroAmplitude, Complex oneAmplitude)
        {
            return new QuantumRegisterArray(zeroAmplitude, oneAmplitude);
        }

        // public override QuantumRegisterAbstract ProduceRegister(params Complex[] array)
        // {
            // return new QuantumRegisterArray(array);
        // }

        public override QuantumRegisterAbstract ProduceRegister(QuantumRegisterAbstract quantumRegisterAbstract)
        {
            return new QuantumRegisterArray(quantumRegisterAbstract);
        }

        public override QuantumRegisterAbstract ProduceRegister(Qubit qubit)
        {
            return qubit.QuantumRegister;
        }

        // public override QuantumRegisterAbstract ProduceRegister(IEnumerable<Complex> enumerable)
        // {
            // return new QuantumRegisterArray(enumerable);
        // }
        
        // public override QuantumRegisterAbstract ProduceRegister(Vector<Complex> register)
        // {
            // return new QuantumRegisterArray(register);
        // }
    }
}
using System.Collections.Generic;
using System.Numerics;
using MathNet.Numerics.LinearAlgebra;
using QuantumComputing;

namespace QuantumComputing
{
    public class QuantumRegisterVectorProducer : QuantumRegisterProducerBase
    {
        public override QuantumRegisterAbstract ProduceRegister(Complex zeroAmplitude, Complex oneAmplitude)
        {
            return new QuantumRegisterVector(zeroAmplitude, oneAmplitude);
        }

        // public override QuantumRegisterAbstract ProduceRegister(params Complex[] array)
        // {
            // return new QuantumRegisterVector(array);
        // }

        public override QuantumRegisterAbstract ProduceRegister(QuantumRegisterAbstract quantumRegisterAbstract)
        {
            return new QuantumRegisterVector(quantumRegisterAbstract);
        }

        public override QuantumRegisterAbstract ProduceRegister(Qubit qubit)
        {
            return qubit.QuantumRegister;
        }

        // public override QuantumRegisterAbstract ProduceRegister(IEnumerable<Complex> enumerable)
        // {
            // return new QuantumRegisterVector(enumerable);
        // }
        
        // public override QuantumRegisterAbstract ProduceRegister(Vector<Complex> register)
        // {
            // return new QuantumRegisterVector(register);
        // }
    }
}
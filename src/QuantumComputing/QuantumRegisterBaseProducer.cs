using System.Collections.Generic;
using System.Numerics;
using MathNet.Numerics.LinearAlgebra;


namespace Lachesis.QuantumComputing
{
    public abstract class QuantumRegisterProducerBase
    {
        public abstract QuantumRegisterAbstract ProduceRegister(Complex zeroAmplitude, Complex oneAmplitude);
        // public abstract QuantumRegisterAbstract ProduceRegister(IEnumerable<Complex> enumerable);
        // public abstract QuantumRegisterAbstract ProduceRegister(Vector<Complex> register);
        
        // public abstract QuantumRegisterAbstract ProduceRegister(params Complex[] array);

        public abstract QuantumRegisterAbstract ProduceRegister(QuantumRegisterAbstract quantumRegisterAbstract);
        public abstract QuantumRegisterAbstract ProduceRegister(Qubit qubit);

    }
}
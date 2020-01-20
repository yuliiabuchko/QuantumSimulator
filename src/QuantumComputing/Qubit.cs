using System;
using System.Numerics;

namespace Lachesis.QuantumComputing
{
    public class Qubit
    {
        public QuantumRegisterAbstract QuantumRegister;

        /*
         * Probability amplitude for state |0>
         */
        public Complex ZeroAmplitude
        {
            get { return this.QuantumRegister.GetRegisterAt(0); }
            private set { this.QuantumRegister.SetRegisterAt(0, value); }
        }

        /*
         * Probability amplitude for state |1>
         */
        public Complex OneAmplitude
        {
            get { return this.QuantumRegister.GetRegisterAt(1); }
            private set { this.QuantumRegister.SetRegisterAt(1, value); }
        }

        /*
         * Constructor from probability amplitudes
         */
        public Qubit(Complex zeroAmplitude, Complex oneAmplitude, QuantumRegisterProducerBase producer)
        {
            QuantumRegister = producer.ProduceRegister(zeroAmplitude, oneAmplitude); //new  QuantumRegisterVector(zeroAmplitude, oneAmplitude);
        }

        /*
         * Constructor from parts of probability amplitudes
         */
        public Qubit(double zeroAmplitudeReal, double zeroAmplitudeImaginary, double oneAmplitudeReal,
            double oneAmplitudeImaginary, QuantumRegisterProducerBase producer)
        {
            QuantumRegister = producer.ProduceRegister(new Complex(zeroAmplitudeReal, zeroAmplitudeImaginary),
                new Complex(oneAmplitudeReal, oneAmplitudeImaginary));
        }

        /*
         * Constructor from Bloch sphere coordinates
         */
        public Qubit(double colatitude, double longitude, QuantumRegisterProducerBase producer)
        {
            QuantumRegister = producer.ProduceRegister(Math.Cos(colatitude / 2),
                Math.Sin(colatitude / 2) * Mathematics.Numerics.ComplexExp(Complex.ImaginaryOne * longitude));
        }

        /*
         * Normalizes a qubit
         */
        protected void Normalize()
        {
            // Normalize magnitude
            QuantumRegister.Normalize();

            // Normalize phase
            if (this.ZeroAmplitude.Phase != 0)
            {
                this.ZeroAmplitude = this.ZeroAmplitude * Complex.FromPolarCoordinates(1, -this.ZeroAmplitude.Phase);
                this.OneAmplitude = this.OneAmplitude * Complex.FromPolarCoordinates(1, -this.ZeroAmplitude.Phase);
            }
        }

        /*
         * |0>
         */
        public static Qubit Zero
        {
            get { return new Qubit(Complex.One, Complex.Zero, new QuantumRegisterVectorProducer()); }
        }

        /*
         * |1>
         */
        public static Qubit One
        {
            get { return new Qubit(Complex.Zero, Complex.One, new QuantumRegisterVectorProducer()); }
        }
    }
}
/*
 * Quantum.NET
 * A library to manipulate qubits and simulate quantum circuits
 * Author: Pierre-Henry Baudin
 */

using System;
using System.Numerics;

namespace Lachesis.QuantumComputing
{
	public class Qubit
	{

		private QuantumRegisterInterface _register;

		private QuantumRegisterProducerBase _producer;
		/*
		 * Probability amplitude for state |0>
		 */
		public Complex ZeroAmplitude
		{
			get
			{
				return this._register.GetRegisterAt(0);
			}
			private set
			{
				this._register.SetRegisterAt(0, value);
			}
		}

		/*
		 * Probability amplitude for state |1>
		 */
		public Complex OneAmplitude
		{
			get
			{
				return this._register.GetRegisterAt(1);
			}
			private set
			{
				this._register.SetRegisterAt(1, value);
			}
		}

		/*
		 * Constructor from probability amplitudes
		 */
		public Qubit(Complex zeroAmplitude, Complex oneAmplitude, QuantumRegisterProducerBase producer)
		{
			_register = producer.ProduceRegister(zeroAmplitude, oneAmplitude);
			_producer = producer;
		}
		
		/*
		 * Normalizes a qubit
		 */
		protected void Normalize()
		{
			// Normalize magnitude
			_register.Normalize();

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
		public static Qubit Zero(QuantumRegisterProducerBase producer)
		{
			return new Qubit(Complex.One, Complex.Zero, producer);
		} 

		/*
		 * |1>
		 */
		
		public static Qubit One(QuantumRegisterProducerBase producer)
		{
			return new Qubit(Complex.Zero, Complex.One, producer);
		}
	}
}

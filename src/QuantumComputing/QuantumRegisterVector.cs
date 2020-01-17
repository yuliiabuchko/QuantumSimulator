/*
 * Quantum.NET
 * A library to manipulate qubits and simulate quantum circuits
 * Author: Pierre-Henry Baudin
 */

using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using QuantumComputing;

namespace Lachesis.QuantumComputing
{
	public class QuantumRegisterVector : QuantumRegisterInterface
	{
		/*
		 * Vector representation of a quantum register
		 */
		public new Vector<Complex> Register { get; protected set; }

		public override Complex GetRegisterAt(int index)
		{
			return Register.At(index);
		}
		
		public override void SetRegisterAt(int index, Complex value)
		{
			Register[index] = value;
		}

		/*
		 * Constructor from probability amplitudes
		 */
		public QuantumRegisterVector(params Complex[] array) : this((IEnumerable<Complex>)array) { }
		
		/*
		 * Constructor from enumerable of probability amplitudes
		 */
		public QuantumRegisterVector(IEnumerable<Complex> enumerable) : this(Vector<Complex>.Build.SparseOfEnumerable(enumerable)) { }

		/*
		 * Constructor from register representation
		 */
		public QuantumRegisterVector(Vector<Complex> register)
		{
			if ((register.Count & (register.Count - 1)) != 0)
			{
				throw new ArgumentException("A quantum register can only be initialized from a register whose dimension is a power of 2.");
			}
			
			this.Register = register;

			this.Normalize();
		}

		/*
		 * Normalizes a quantum register
		 */
		public override void Normalize()
		{
			// Normalize magnitude
			double magnitudeFactor = Math.Sqrt(this.Register.Aggregate(0.0, (factor, amplitude) => factor + amplitude.MagnitudeSquared()));
			if (magnitudeFactor != 1)
			{
				this.Register = this.Register / magnitudeFactor;
			}
		}

		/*
		 * Collapses a quantum register into a pure state
		 */
		public override void Collapse(Random random)
		{
			Vector<Complex> collapsedVector = Vector<Complex>.Build.Sparse(this.Register.Count);
			double probabilitySum = 0d;
			double probabilityThreshold = random.NextDouble();

			for (int i = 0; i < this.Register.Count; i++)
			{
				probabilitySum += this.Register.At(i).MagnitudeSquared();

				if (probabilitySum > probabilityThreshold)
				{
					collapsedVector.At(i, Complex.One);
					break;
				}
			}

			this.Register = collapsedVector;
		}

		/*
		 * Returns the value contained in a quantum register, with optional portion start and length
		 */
		public override int GetValue(int portionStart = 0, int portionLength = 0)
		{
			int registerLength = Mathematics.Numerics.Log2(this.Register.Count - 1);
			
			if (portionLength == 0)
			{
				portionLength = registerLength - portionStart;
			}

			int trailingBitCount = registerLength - portionStart - portionLength;

			if (trailingBitCount < 0)
			{
				throw new ArgumentException("The supplied portion overflows the given quantum register.");
			}

			int index = -1;

			for (int i = 0; i < this.Register.Count; i++)
			{
				if (this.Register.At(i) == 1)
				{
					index = i;
					break;
				}
			}

			if (index == -1)
			{
				throw new SystemException("A value can only be extracted from a pure state quantum register.");
			}

			// If trailing bits need to be removed
			if (trailingBitCount > 0)
			{
				index >>= trailingBitCount;
			}

			// If leading bits need to be removed
			if (portionStart > 0)
			{
				index &= (1 << portionLength) - 1;
			}

			return index;
		}
		

		/*
		 * String representation of a quantum register
		 */
		public override string ToString()
		{
			string representation = "";

			for (int i = 0; i < this.Register.Count; i++)
			{
				Complex amplitude = this.Register.At(i);

				if (amplitude != 0)
				{
					string complexString = "";

					if (amplitude.Real < 0 || amplitude.Real == 0 && amplitude.Imaginary < 0)
					{
						complexString += " - ";
						amplitude = -amplitude;
					}
					else if (representation.Length > 0)
					{
						complexString += " + ";
					}

					if (amplitude != 1)
					{
						if (amplitude.Real != 0 && amplitude.Imaginary != 0)
						{
							complexString += "(";
						}

						if (amplitude.Real != 0)
						{
							complexString += amplitude.Real;
						}

						if (amplitude.Real != 0 && amplitude.Imaginary > 0)
						{
							complexString += " + ";
						}

						if (amplitude.Imaginary != 0)
						{
							complexString += amplitude.Imaginary + " i";
						}

						if (amplitude.Real != 0 && amplitude.Imaginary != 0)
						{
							complexString += ")";
						}

						complexString += " ";
					}

					representation += complexString + "|" + Convert.ToString(i, 2) + ">";
				}
			}

			return representation;
		}

		/*
		 * Determines whether the specified quantum register is equal to the current quantum register
		 */
		public override bool Equals(object obj)
		{
			QuantumRegisterVector quantumRegisterVector = obj as QuantumRegisterVector;

			if (quantumRegisterVector == null || this.Register.Count != quantumRegisterVector.Register.Count)
			{
				return false;
			}

			return this.Register.Equals(quantumRegisterVector.Register);
		}

		/*
		 * Serves as a hash function for a quantum register
		 */
		public override int GetHashCode()
		{
			return this.Register.GetHashCode();
		}
	}
}

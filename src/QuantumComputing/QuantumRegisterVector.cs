using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace Lachesis.QuantumComputing
{
	public class QuantumRegisterVector : QuantumRegisterAbstract
	{
		/*
		 * Vector representation of a quantum register
		 */
		public new Vector<Complex> Vector { get; protected set; }

		/*
		 * Constructor from integer
		 */
		public QuantumRegisterVector(int value, int bitCount = 0) : this(Mathematics.LinearAlgebra.VectorFromInteger(value, bitCount)) { }

		/*
		 * Constructor from other quantum registers
		 */
		public QuantumRegisterVector(params QuantumRegisterVector[] quantumRegisters) : this((IEnumerable<QuantumRegisterVector>)quantumRegisters) { }

		/*
		 * Constructor from enumerable of other quantum registers
		 */
		public QuantumRegisterVector(IEnumerable<QuantumRegisterVector> quantumRegisters)
		{
			this.Vector = quantumRegisters.Aggregate(Vector<Complex>.Build.Sparse(1, Complex.One), (vector, quantumRegister) => Mathematics.LinearAlgebra.CartesianProduct(vector, quantumRegister.Vector));
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
		 * Constructor from vector representation
		 */
		public QuantumRegisterVector(Vector<Complex> vector)
		{
			if ((vector.Count & (vector.Count - 1)) != 0)
			{
				throw new ArgumentException("A quantum register can only be initialized from a vector whose dimension is a power of 2.");
			}
			
			this.Vector = vector;

			this.Normalize();
		}

		/*
		 * Normalizes a quantum register
		 */
		public override void Normalize()
		{
			// Normalize magnitude
			double magnitudeFactor = Math.Sqrt(this.Vector.Aggregate(0.0, (factor, amplitude) => factor + amplitude.MagnitudeSquared()));
			if (magnitudeFactor != 1)
			{
				this.Vector = this.Vector / magnitudeFactor;
			}
		}

		/*
		 * Collapses a quantum register into a pure state
		 */
		
		// TODO need
		public override void Collapse(Random random)
		{
			Vector<Complex> collapsedVector = Vector<Complex>.Build.Sparse(this.Vector.Count);
			double probabilitySum = 0d;
			double probabilityThreshold = random.NextDouble();

			for (int i = 0; i < this.Vector.Count; i++)
			{
				probabilitySum += this.Vector.At(i).MagnitudeSquared();

				if (probabilitySum > probabilityThreshold)
				{
					collapsedVector.At(i, Complex.One);
					break;
				}
			}

			this.Vector = collapsedVector;
		}

		/*
		 * Returns the value contained in a quantum register, with optional portion start and length
		 */
		// TODO need

		public override int GetValue(int portionStart = 0, int portionLength = 0)
		{
			int registerLength = Mathematics.Numerics.Log2(this.Vector.Count - 1);
			
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

			for (int i = 0; i < this.Vector.Count; i++)
			{
				if (this.Vector.At(i) == 1)
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

			for (int i = 0; i < this.Vector.Count; i++)
			{
				Complex amplitude = this.Vector.At(i);

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
			QuantumRegisterVector quantumRegister = obj as QuantumRegisterVector;

			if (quantumRegister == null || this.Vector.Count != quantumRegister.Vector.Count)
			{
				return false;
			}

			return this.Vector.Equals(quantumRegister.Vector);
		}

		/*
		 * Determines whether the specified quantum register is equal to the current quantum register, ignoring floating-point precision issues
		 */
		public bool AlmostEquals(object obj)
		{
			QuantumRegisterVector quantumRegister = obj as QuantumRegisterVector;

			if (quantumRegister == null || this.Vector.Count != quantumRegister.Vector.Count)
			{
				return false;
			}

			return Precision.AlmostEqual<Complex>(this.Vector, quantumRegister.Vector, 15);
		}

		/*
		 * Serves as a hash function for a quantum register
		 */
		public override int GetHashCode()
		{
			return this.Vector.GetHashCode();
		}
		
		public override Complex GetRegisterAt(int index)
		{
			return Vector.At(index);
		}

		public override void SetRegisterAt(int index, Complex value)
		{
			Vector.At(index, value);
		}
	}
}

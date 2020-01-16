using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using MathNet.Numerics;
using MathNet.Numerics.LinearAlgebra;

namespace Lachesis.QuantumComputing
{
    public class QuantumRegisterArray : AbstractQuantumRegister
    {
        // TODO convert to array
        /*
		 * Array representation of a quantum register
		 */
        public new Vector<Complex> Register { get; protected set; }
        public override Complex getRegisterAt(int index)
        {
            // todo array
            return Register.At(index);
        }
		
        public override void setRegisterAt(int index, Complex value)
        {
            // todo ереробити на масив
            Register.At(index, value);
        }
        /*
		 * Constructor from integer
		 */
        public QuantumRegisterArray(int value, int bitCount = 0) : this(Mathematics.LinearAlgebra.VectorFromInteger(value, bitCount)) { }

        /*
		 * Constructor from other quantum registers
		 */
        // todo
        public QuantumRegisterArray(params QuantumRegisterVector[] quantumRegisters) : this((IEnumerable<QuantumRegisterVector>)quantumRegisters) { }

        /*
		 * Constructor from enumerable of other quantum registers
		 */
        public QuantumRegisterArray(IEnumerable<QuantumRegisterVector> quantumRegisters)
        {
            this.Register = quantumRegisters.Aggregate(Vector<Complex>.Build.Sparse(1, Complex.One), (vector, quantumRegister) => Mathematics.LinearAlgebra.CartesianProduct(vector, quantumRegister.Register));
        }

        /*
		 * Constructor from probability amplitudes
		 */
        public QuantumRegisterArray(params Complex[] array) : this((IEnumerable<Complex>)array) { }

        /*
		 * Constructor from enumerable of probability amplitudes
		 */
        public QuantumRegisterArray(IEnumerable<Complex> enumerable) : this(Vector<Complex>.Build.SparseOfEnumerable(enumerable)) { }

        /*
		 * Constructor from register representation
		 */
        public QuantumRegisterArray(Vector<Complex> register)
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
        protected override void Normalize()
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

        // TODO шо єто такоє і вроді нам того не нід
        /*
		 * Einstein–Podolsky–Rosen pair
		 */
        public static QuantumRegisterArray EPRPair
        {
            get
            {
                return new QuantumRegisterArray(Vector<Complex>.Build.SparseOfArray(new Complex[] { Complex.One, Complex.Zero, Complex.Zero, Complex.One }) / Math.Sqrt(2));
            }
        }

        /*
		 * W state
		 */
        public static QuantumRegisterArray WState
        {
            get
            {
                return QuantumRegisterArray.WStateOfLength(3);
            }
        }

        /*
		 * Generalized W state
		 */
        public static QuantumRegisterArray WStateOfLength(int length)
        {
            Vector<Complex> vector = Vector<Complex>.Build.Sparse(1 << length);

            for (int i = 0; i < length; i++)
            {
                vector.At(1 << i, Complex.One);
            }
			
            return new QuantumRegisterArray(vector / Math.Sqrt(3));
        }

        /*
		 * Simplest Greenberger–Horne–Zeilinger state
		 */
        public static QuantumRegisterArray GHZState
        {
            get
            {
                return QuantumRegisterArray.GHZStateOfLength(3);
            }
        }

        /*
		 * Greenberger–Horne–Zeilinger state
		 */
        public static QuantumRegisterArray GHZStateOfLength(int length)
        {
            Vector<Complex> vector = Vector<Complex>.Build.Sparse(1 << length);

            vector.At(0, Complex.One);
            vector.At((1 << length) - 1, Complex.One);

            return new QuantumRegisterArray(vector / Math.Sqrt(2));
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
            QuantumRegisterArray quantumRegisterVector = obj as QuantumRegisterArray;

            if (quantumRegisterVector == null || this.Register.Count != quantumRegisterVector.Register.Count)
            {
                return false;
            }

            return this.Register.Equals(quantumRegisterVector.Register);
        }

        /*
		 * Determines whether the specified quantum register is equal to the current quantum register, ignoring floating-point precision issues
		 */
        public override bool AlmostEquals(object obj)
        {
            QuantumRegisterArray quantumRegisterVector = obj as QuantumRegisterArray;

            if (quantumRegisterVector == null || this.Register.Count != quantumRegisterVector.Register.Count)
            {
                return false;
            }

            return Precision.AlmostEqual<Complex>(this.Register, quantumRegisterVector.Register, 15);
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
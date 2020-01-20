using System;
using System.Numerics;
using MathNet.Numerics.LinearAlgebra;

namespace Lachesis.QuantumComputing
{
    public abstract class QuantumRegisterAbstract
    {
        public object Vector;

        public abstract void Normalize();
        public abstract void Collapse(Random random);
        public abstract int GetValue(int portionStart = 0, int portionLength = 0);
        public abstract override string ToString();
        public abstract override bool Equals(object obj);
        public abstract override int GetHashCode();

        public abstract Complex GetRegisterAt(int index);
        public abstract void SetRegisterAt(int index, Complex value);
        public object Register;
    }
}
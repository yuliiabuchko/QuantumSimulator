using System;
using System.Numerics;

namespace Lachesis.QuantumComputing
{
    public abstract class QuantumRegisterInterface
    {
        public abstract void Normalize();
        public abstract void Collapse(Random random);
        public abstract int GetValue(int portionStart = 0, int portionLength = 0);
        public abstract override string ToString();
        public abstract override bool Equals(object obj);
        public abstract bool AlmostEquals(object obj);
        public abstract override int GetHashCode();

        public abstract Complex getRegisterAt(int index);
        public abstract void setRegisterAt(int index, Complex value);
        public object Register;

    }
}
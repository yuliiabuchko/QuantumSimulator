/*
 * Quantum.NET
 * A library to manipulate qubits and simulate quantum circuits
 * Author: Pierre-Henry Baudin
 */

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Numerics;

namespace Lachesis.QuantumComputing.Tests
{
	[TestClass]
	public class QuantumRegisterTests
	{
		private static Random Random;

		[ClassInitialize]
		public static void ClassInit(TestContext context)
		{
			QuantumRegisterTests.Random = new Random();
		}

		[TestMethod]
		public void QuantumRegister_FromInteger_IsValid()
		{
			Assert.AreEqual(new QuantumRegisterVector(15), new QuantumRegisterVector(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1));
		}

		[TestMethod]
		public void QuantumRegister_FromIntegerWithBitCount_IsValid()
		{
			Assert.AreEqual(new QuantumRegisterVector(7, 4), new QuantumRegisterVector(0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0));
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentException))]
		public void QuantumRegister_FromIntegerWithLowBitCount_ThrowsArgumentException()
		{
			QuantumRegisterVector quantumRegisterVector = new QuantumRegisterVector(7, 2);
		}

		[TestMethod]
		public void QuantumRegister_FromQuantumRegisters_IsValid()
		{
			Assert.AreEqual(new QuantumRegisterVector(Qubit.One, QuantumRegisterVector.EPRPair), new QuantumRegisterVector(0, 0, 0, 0, 1 / Math.Sqrt(2), 0, 0, 1 / Math.Sqrt(2)));
		}

		[TestMethod]
		public void QuantumRegister_FromVector_IsValid()
		{
			Assert.AreEqual(new QuantumRegisterVector(QuantumRegisterVector.EPRPair.Register), QuantumRegisterVector.EPRPair);
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentException))]
		public void QuantumRegister_FromVectorNotInAPowerOfTwoDimension_ThrowsArgumentException()
		{
			QuantumRegisterVector quantumRegisterVector = new QuantumRegisterVector(Complex.One, Complex.Zero, Complex.One);
		}

		[TestMethod]
		public void QuantumRegister_CollapsePureState_StaysTheSame()
		{
			QuantumRegisterVector zeroOne = new QuantumRegisterVector(Qubit.Zero, Qubit.One);
			zeroOne.Collapse(QuantumRegisterTests.Random);
			Assert.AreEqual(zeroOne, new QuantumRegisterVector(Qubit.Zero, Qubit.One));
		}

		[TestMethod]
		public void QuantumRegister_CollapseEPRPair_Is00Or11()
		{
			QuantumRegisterVector quantumRegisterVector = QuantumRegisterVector.EPRPair;
			quantumRegisterVector.Collapse(QuantumRegisterTests.Random);
			Assert.IsTrue(quantumRegisterVector.Equals(new QuantumRegisterVector(Qubit.Zero, Qubit.Zero)) || quantumRegisterVector.Equals(new QuantumRegisterVector(Qubit.One, Qubit.One)));
		}

		[TestMethod]
		public void QuantumRegister_CollapseWState_WithRandomMock_Is001()
		{
			QuantumRegisterVector quantumRegisterVector = QuantumRegisterVector.WState;
			Random randomMock = Mock.Of<Random>();
			Mock.Get(randomMock).Setup(random => random.NextDouble()).Returns(0.2);
			quantumRegisterVector.Collapse(randomMock);
			Assert.IsTrue(quantumRegisterVector.Equals(new QuantumRegisterVector(Qubit.Zero, Qubit.Zero, Qubit.One)));
		}

		[TestMethod]
		public void QuantumRegister_GetValue_IsValid()
		{
			QuantumRegisterVector quantumRegisterVector = new QuantumRegisterVector(27);

			Assert.AreEqual(quantumRegisterVector.GetValue(), 27);
			Assert.AreEqual(quantumRegisterVector.GetValue(1), 11);
			Assert.AreEqual(quantumRegisterVector.GetValue(1, 3), 5);
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentException))]
		public void QuantumRegister_GetValueWithOverflow_ThrowsArgumentException()
		{
			QuantumRegisterVector quantumRegisterVector = new QuantumRegisterVector(5);
			quantumRegisterVector.GetValue(1, 3);
		}

		[TestMethod]
		[ExpectedException(typeof(SystemException))]
		public void QuantumRegister_GetValueOnMixedState_ThrowsSystemException()
		{
			Qubit.EPRPair.GetValue();
		}
	}
}

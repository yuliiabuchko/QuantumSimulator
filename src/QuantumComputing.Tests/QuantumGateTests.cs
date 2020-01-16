/*
 * Quantum.NET
 * A library to manipulate qubits and simulate quantum circuits
 * Author: Pierre-Henry Baudin
 */

using MathNet.Numerics.IntegralTransforms;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Numerics;

namespace Lachesis.QuantumComputing.Tests
{
	[TestClass]
	public class QuantumGateTests
	{
		[TestMethod]
		public void QuantumGate_HadamardGateOfLength2_IsValid()
		{
			Assert.IsTrue(QuantumGate.HadamardGateOfLength(2).AlmostEquals(new QuantumGate(new Complex[,] {
				{ 0.5, 0.5, 0.5, 0.5 },
				{ 0.5, -0.5, 0.5, -0.5 },
				{ 0.5, 0.5, -0.5, -0.5 },
				{ 0.5, -0.5, -0.5, 0.5 },
			})));
		}

		[TestMethod]
		public void QuantumGate_PhaseShiftGateFromPiOverTwo_IsValid()
		{
			Assert.IsTrue(QuantumGate.PhaseShiftGate(Math.PI / 2).AlmostEquals(new QuantumGate(new Complex[,] {
				{ 1, 0 },
				{ 0, Complex.ImaginaryOne },
			})));
		}

		[TestMethod]
		public void QuantumGate_ControlledGateFromNotGate_IsValid()
		{
			Assert.AreEqual(QuantumGate.ControlledGate(QuantumGate.NotGate), new QuantumGate(new Complex[,] {
				{ 1, 0, 0, 0 },
				{ 0, 1, 0, 0 },
				{ 0, 0, 0, 1 },
				{ 0, 0, 1, 0 },
			}));
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentException))]
		public void QuantumGate_ControlledGateFromControlledNotGate_ThrowsArgumentException()
		{
			QuantumGate quantumGate = QuantumGate.ControlledGate(QuantumGate.ControlledGate(QuantumGate.NotGate));
		}

		// [TestMethod]
		// public void QuantumGate_QuantumFourierTranform_IsValid()
		// {
		// 	// Start with unnormalized samples
		// 	Complex[] samples = new Complex[] { Complex.One, Complex.One + Complex.ImaginaryOne, Complex.ImaginaryOne, Complex.One - Complex.ImaginaryOne, Complex.One, Complex.Zero, Complex.ImaginaryOne, Complex.ImaginaryOne };
		//
		// 	// Create a quantum register from samples
		// 	QuantumRegisterVector quantumRegisterVector = new QuantumRegisterVector(samples);
		//
		// 	// Get normalized samples
		// 	samples = quantumRegisterVector.Register.ToArray();
		//
		// 	// Transform quantum register
		// 	quantumRegisterVector = QuantumGate.QuantumFourierTransform(3) * quantumRegisterVector;
		//
		// 	// Transform samples independently using Math.NET
		// 	Fourier.Inverse(samples);
		//
		// 	// Compare results
		// 	Assert.IsTrue(quantumRegisterVector.AlmostEquals(new QuantumRegisterVector(samples)));
		// }

		[TestMethod]
		public void QuantumGate_ApplicationToQuantumRegister_IsValid()
		{
			Assert.AreEqual(QuantumGate.NotGate * Qubit.Zero, Qubit.One);
		}

		[TestMethod]
		public void QuantumGate_CombinedApplicationToQuantumRegister_IsValid()
		{
			QuantumGate quantumGate = new QuantumGate(QuantumGate.NotGate, QuantumGate.IdentityGate);
			QuantumRegisterVector quantumRegisterVector = new QuantumRegisterVector(Qubit.Zero, Qubit.One);
			Assert.AreEqual(quantumGate * quantumRegisterVector, new QuantumRegisterVector(Qubit.One, Qubit.One));
		}
	}
}

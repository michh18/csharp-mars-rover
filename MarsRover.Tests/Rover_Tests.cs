using NUnit.Framework.Constraints;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover.Tests
{
    internal class Rover_Tests
    {
        // ================================ Rotate Tests =========================================
        [TestCase(CompassDirection.N, Instruction.R, CompassDirection.E)]
        [TestCase(CompassDirection.E, Instruction.R, CompassDirection.S)]
        [TestCase(CompassDirection.S, Instruction.R, CompassDirection.W)]
        [TestCase(CompassDirection.W, Instruction.R, CompassDirection.N)]
        public void Rotate_ShouldReturnCorrectDirection_WhenRotatingRight(CompassDirection facing, Instruction rotateInstruction, CompassDirection expected)
        {
            var result = Rover.Rotate(facing, rotateInstruction);
            Assert.That(result, Is.EqualTo(expected));
        }

        [TestCase(CompassDirection.N, Instruction.L, CompassDirection.W)]
        [TestCase(CompassDirection.E, Instruction.L, CompassDirection.N)]
        [TestCase(CompassDirection.S, Instruction.L, CompassDirection.E)]
        [TestCase(CompassDirection.W, Instruction.L, CompassDirection.S)]
        public void Rotate_ShouldReturnCorrectDirection_WhenRotatingLeft(CompassDirection facing, Instruction rotateInstruction, CompassDirection expected)
        {
            var result = Rover.Rotate(facing, rotateInstruction);
            Assert.That(result, Is.EqualTo(expected));
        }

        [TestCase(CompassDirection.N, Instruction.M)]
        public void Rotate_ShouldThrowFormatException_WhenUsingInstructionM(CompassDirection facing, Instruction rotateInstruction)
        {
            string expected = "Invalid rotation instruction.";
            var ex = Assert.Throws<FormatException>(() => Rover.Rotate(facing, rotateInstruction));
            Assert.That(ex.Message.ToString(), Does.Contain(expected));
        }

        [TestCase("1")]
        [TestCase("1 2 3")]
        public void PlateauParser_ShouldThrowArgumentException_WhenStringDoesNotContainExactlyTwoIntegers(string input)
        {
            string expected = "Need a string of exactly 2 numbers!";
            var ex = Assert.Throws<ArgumentException>(() => InputParser.PlateauParser(input));
            Assert.That(ex.Message.ToString(), Does.Contain(expected));
        }

        [TestCase("a 1")]
        [TestCase("a b")]
        public void PlateauParser_ShouldThrowFormatException_WhenStringContainsSomeAndNoIntegers(string input)
        {
            string expected = "Input must contain valid integers.";
            var ex = Assert.Throws<FormatException>(() => InputParser.PlateauParser(input));
            Assert.That(ex.Message.ToString(), Does.Contain(expected));
        }

        [TestCase("-5 -5")]
        [TestCase("-5 0")]
        [TestCase("0 0")]
        public void PlateauParser_ShouldThrowArgumentOutOfRangeException_WhenParsedStringOfNegativeIntsOrBothZeros(string input)
        {
            string expected = "Coordinates must be positive integers.";
            var ex = Assert.Throws<ArgumentOutOfRangeException>(() => InputParser.PlateauParser(input));
            Assert.That(ex.Message.ToString(), Does.Contain(expected));
        }
    }
}

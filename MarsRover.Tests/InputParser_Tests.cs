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
    internal class InputParser_Tests
    {

        [TestCase("")]
        [TestCase("       ")]
        public void PlateauParser_ShouldReturnException_WhenParsedEmptyStringOrWhiteSpace(string input)
        {
            string expected = "Input cannot be null or empty.";
            var ex = Assert.Throws<ArgumentException>(() => InputParser.PlateauParser(input));
            Assert.That(ex.Message.ToString(), Does.Contain(expected));
        }

        [TestCase("1")]
        [TestCase("1 2 3")]
        public void PlateauParser_ShouldReturnException_WhenStringDoesntContainExactlyTwoIntegers(string input)
        {
            string expected = "Need a string of exactly 2 numbers!";
            var ex = Assert.Throws<ArgumentException>(() => InputParser.PlateauParser(input));
            Assert.That(ex.Message.ToString(), Does.Contain(expected));
        }

        [TestCase("a 1")]
        [TestCase("a b")]
        public void PlateauParser_ShouldReturnFormatException_WhenStringContainsSomeAndNoIntegers(string input)
        {
            string expected = "Input must contain valid integers.";
            var ex = Assert.Throws<FormatException>(() => InputParser.PlateauParser(input));
            Assert.That(ex.Message.ToString(), Does.Contain(expected));
        }

        [TestCase("-5 -5")]
        [TestCase("-5 0")]
        [TestCase("0 0")]
        public void PlateauParser_ShouldReturnArgumentOutOfRangeException_WhenParsedStringOfNegativeIntsOrBothZeros(string input)
        {
            string expected = "Coordinates must be positive integers.";
            var ex = Assert.Throws<ArgumentOutOfRangeException>(() => InputParser.PlateauParser(input));
            Assert.That(ex.Message.ToString(), Does.Contain(expected));
        }

        [TestCase("5 5", 5, 5)]
        [TestCase("4 5", 4, 5)]
        [TestCase("3 6", 3, 6)]
        public void PlateauParser_ShouldReturnCorrectPlateau_WhenParsedStringOfTwoPositiveNums(string input, int x, int y)
        {
            (int, int) result = InputParser.PlateauParser(input);
            Assert.That(result, Is.EqualTo((x,y)));
        }

        [Test]
        public void InstructionParser_ShouldReturnValidFormat_WhenParsedStringWithSomeActions()
        {
            string input1 = "LMRHAJREAJEM";
            string input2 = "AAAALNM";
            
            var result1 = InputParser.InstructionParser(input1);
            var result2 = InputParser.InstructionParser(input2);

            Assert.That(result1, Is.EqualTo(new List<Instruction>() { Instruction.L, Instruction.M, Instruction.R, Instruction.R, Instruction.M }));
            Assert.That(result2, Is.EqualTo(new List<Instruction>() { Instruction.L, Instruction.M }));
        }

        [Test]
        public void InstructionParser_ShouldReturnEmptyString_WhenParsedEmptyStringOrNoActions()
        {
            string input1 = "";
            string input2 = "AAABBB";
            string input3 = "AA1BBB";

            var result1 = InputParser.InstructionParser(input1);
            var result2 = InputParser.InstructionParser(input2);
            var result3 = InputParser.InstructionParser(input3);

            Assert.That(result1, Is.EqualTo(new List<Instruction> { }));
            Assert.That(result2, Is.EqualTo(new List<Instruction> { }));
            Assert.That(result3, Is.EqualTo(new List<Instruction> { }));
        }
    }
}

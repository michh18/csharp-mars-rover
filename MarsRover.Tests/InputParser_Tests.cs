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
        [TestCase("1")]
        [TestCase("1 2 3")]
        public void PlateauParser_ShouldReturnException_WhenStringDoesntContainTwoIntegers(string input)
        {
            string expected = "Parsing failed: Need a string of exactly 2 numbers!";
            var ex = Assert.Throws<Exception>(() => InputParser.PlateauParser(input));
            Assert.That(ex.Message.ToString(), Is.EqualTo(expected));
        }

        [TestCase("a 1")]
        [TestCase("a b")]
        public void PlateauParser_ShouldReturnFormatException_WhenStringContainsSomeAndNoIntegers(string input)
        {
            string expected = "Parsing failed: Input string didn't contain two numbers";
            var ex = Assert.Throws<FormatException>(() => InputParser.PlateauParser(input));
            Assert.That(ex.Message.ToString(), Is.EqualTo(expected));
        }

        [TestCase("5 5", 5, 5)]
        [TestCase("4 5", 4, 5)]
        [TestCase("3 6", 3, 6)]
        public void PlateauParser_ShouldReturnCorrectPlateau_WhenParsedStringOfTwoNums(string input, int x, int y)
        {
            (int, int) result = InputParser.PlateauParser(input);

            Assert.That(result.Item1, Is.EqualTo(x));
            Assert.That(result.Item2, Is.EqualTo(y));
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

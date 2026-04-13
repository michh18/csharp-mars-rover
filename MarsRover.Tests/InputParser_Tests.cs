using NUnit.Framework.Constraints;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
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
        public void InformationParser_ShouldReturn_When() { }
    }
}

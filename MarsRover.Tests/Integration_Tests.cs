using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover.Tests
{
    public class Integration_Tests
    {
        [Test]
        public void FullRun_ReturnsCorrectFinalPositions_GivenExampleInput()
        {
            List<string> input = new List<string>()
            {
                "5 5",
                "1 2 N",
                "LMLMLMLMM",
                "3 3 E",
                "MMRMMRMRRM"
            };

            PlateauSize processedPlateau = InputParser.PlateauParser(input[0]);

            // Rover 1 
            Position position1 = InputParser.PositionParser(input[1]);
            List<Instruction> instructions1 = InputParser.InstructionParser(input[2]);

            var finalPosition1 = Rover.ExecuteInstructions(processedPlateau, position1, instructions1);

            // Rover 2
            Position position2 = InputParser.PositionParser(input[3]);
            List<Instruction> instructions2 = InputParser.InstructionParser(input[4]);

            var finalPosition2 = Rover.ExecuteInstructions(processedPlateau, position2, instructions2);

            Assert.That(finalPosition1, Is.EqualTo(new Position(1, 3, CompassDirection.N)));
            Assert.That(finalPosition2, Is.EqualTo(new Position(5, 1, CompassDirection.E)));
        }

        [Test]
        public void FullRun_ReturnsCorrectFinalPosition_GivenOnlyRotations()
        {
            List<string> input = new List<string>()
            {
                "5 5",
                "1 2 N",
                "RR",
            };

            PlateauSize processedPlateau = InputParser.PlateauParser(input[0]);
            Position position = InputParser.PositionParser(input[1]);
            List<Instruction> instructions = InputParser.InstructionParser(input[2]);

            var finalPosition = Rover.ExecuteInstructions(processedPlateau, position, instructions);

            Assert.That(finalPosition, Is.EqualTo(new Position(1, 2, CompassDirection.S)));
        }
        [Test]
        public void FullRun_ReturnsCorrectFinalPosition_GivenOnlyMovements()
        {
            List<string> input = new List<string>()
            {
                "5 5",
                "1 2 N",
                "MMM",
            };

            PlateauSize processedPlateau = InputParser.PlateauParser(input[0]);
            Position position = InputParser.PositionParser(input[1]);
            List<Instruction> instructions = InputParser.InstructionParser(input[2]);

            var finalPosition = Rover.ExecuteInstructions(processedPlateau, position, instructions);

            Assert.That(finalPosition, Is.EqualTo(new Position(1, 5, CompassDirection.N)));
        }

    }
}
